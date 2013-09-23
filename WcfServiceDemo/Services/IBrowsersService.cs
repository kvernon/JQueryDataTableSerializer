using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using CubedElement.DataTable.Model;
using WcfServiceDemo.Data;
using WcfServiceDemo.Model;

namespace WcfServiceDemo.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(object))]
    [ServiceKnownType(typeof(KeyValue<string, object>))]
    [ServiceKnownType(typeof(Browser))]
    [ServiceKnownType(typeof(object[]))]
    [ServiceKnownType(typeof(BrowserDataTableWrap))]
    [ServiceKnownType(typeof(DataTableWrapper<BrowserDataTableWrap>))]
    public interface IBrowsersService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Api/BrowsersService/{value}")]
        string GetData(string value);

        /*[OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);*/

        // TODO: Add your service operations here
        [OperationContract]
        [WebGet(UriTemplate = "Api/BrowsersService/")]
        IList<IBrowser> GetAll();

        [OperationContract]
        [WebInvoke(UriTemplate = "Api/BrowsersService/in/", Method = "POST",
                   BodyStyle = WebMessageBodyStyle.WrappedRequest,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        IList<KeyValue<string, object>> Results(IList<KeyValue<string, object>> instance);

        [OperationContract]
        [WebInvoke(UriTemplate = "Api/BrowsersService/", Method = "POST", 
                   BodyStyle = WebMessageBodyStyle.WrappedRequest, 
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        DataTableWrapper<BrowserDataTableWrap> GetCollectionByDataTable(IList<KeyValue<string, object>> instance);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
