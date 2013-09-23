using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using CubedElement.DataTable.Model;
using CubedElement.DataTable.Model.Constants;
using WcfServiceDemo.Data;
using WcfServiceDemo.Model;

namespace WcfServiceDemo.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BrowserService : IBrowsersService
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IList<IBrowser> GetAll()
        {
            return new BrowserData().GetAll();
        }

        public IList<KeyValue<string, object>> Results(IList<KeyValue<string, object>> instance)
        {
            return instance;
        }

        /// <summary>
        /// This is an example to show how you might transform the data results. Typically this stuff is pushed further back into a business layer or in a repository of some sort.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public DataTableWrapper<BrowserDataTableWrap> GetCollectionByDataTable(IList<KeyValue<string, object>> instance)
        {
            if (instance == null)
            {
                throw new WebFaultException<string>("there are no vars being passed in for the action", HttpStatusCode.BadRequest);
            }

            var hasGlobalSearch = instance.FirstOrDefault(i => i.Key.Contains(DataItemCollectionNames.SSearch.Replace("_", string.Empty)));

            var hasEcho = instance.FirstOrDefault(i => i.Key.Contains(DataItemPropertyNamesFrontEnd.Echo));

            var hasColSorted = instance.FirstOrDefault(i => i.Key.Contains(DataItemCollectionNames.SSortCol));

            var hasDisplayStart = instance.FirstOrDefault(i => i.Key.Contains(DataItemPropertyNamesFrontEnd.DisplayStart));

            var hasDisplayLength = instance.FirstOrDefault(i => i.Key.Contains(DataItemPropertyNamesFrontEnd.DisplayLength));

            // This may seem like a lot, but typically you set up 'defaults' in an IOC like Ninject, StructureMap, or Unity
            var trans = new DataTableRequestCollection
                {
                    Echo = hasEcho != null ? hasEcho.Value.ToString() : string.Empty,
                    GlobalSearch = hasGlobalSearch != null ? hasGlobalSearch.Value.ToString() : string.Empty,
                    DataProperties = new Dictionary<string, string>(),
                    ColumnSortable = new Dictionary<string, bool>(),
                    ColumnRegExpression = new Dictionary<string, bool>(),
                    ColumnSearch = new Dictionary<string, string>(),
                    ColumnSearchable = new Dictionary<string, bool>(),
                    ColumnSortDirection = new Dictionary<string, string>(),
                    ColumnSorted = hasColSorted != null ? int.Parse(hasColSorted.Value.ToString()) : 0,
                    DisplayStart = hasDisplayStart != null ? int.Parse(hasDisplayStart.Value.ToString()) : 0,
                    DisplayLength = hasDisplayLength != null ? int.Parse(hasDisplayLength.Value.ToString()) : 0,
                };

            foreach (var i in instance.Where(i => i.Key.Contains(DataItemCollectionNames.MdataProp)))
            {
                trans.DataProperties.Add(new KeyValuePair<string, string>(i.Key, i.Value.ToString()));
            }

            var browserData = new BrowserData();

            var collectionByDataTable = !string.IsNullOrEmpty(trans.GlobalSearch)
                                            ? browserData.GetGlobalFiltered(trans.GlobalSearch)
                                            : browserData.GetFiltered(trans.SortedColumnSearchName, 
                                                                      trans.SortedColumnSearchValue, 
                                                                      trans.SortedColumnDirectionValue.ToLower() == "asc");

            // it's a cheat that says count all the data
            var totalRecords = GetAll().Count;

            // this is another cheat that says count all the filtered results
            var totalDisplay = collectionByDataTable.Count;

            // now we start to transform this class to a the one that implements the IDataTableSerializer 
            var transformed = new List<BrowserDataTableWrap>(); 
            
            // simple loop
            foreach (var browser in browserData.Reduce(collectionByDataTable, trans.DisplayStart, trans.DisplayLength))
            {
                var browserDataTableWrap = new BrowserDataTableWrap
                    {
                        Engine = browser.Engine,
                        Grade = browser.Grade,
                        Name = browser.Name,
                        Platform = browser.Platform,
                        Version = browser.Version,
                    };

                transformed.Add(browserDataTableWrap);
            }

            // finally, input the results into the datatable
            var dataTableWrapper = new DataTableWrapper<BrowserDataTableWrap>(trans, transformed)
                {
                    TotalRecords = totalRecords, // typically this total would be return in database
                    TotalDisplayRecords = totalDisplay // this is the max amount of filtererd matches
                };

            return dataTableWrapper;
        }
    }
}
