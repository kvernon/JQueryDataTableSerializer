using System.Collections.Generic;
using System.Linq;
using CubedElement.DataTable.Contracts.Extensions;
using WcfServiceDemo.Model;

namespace WcfServiceDemo.Data
{
    public class BrowserData
    {
        /// <summary>
        /// returns everything
        /// </summary>
        /// <returns></returns>
        public List<IBrowser> GetAll()
        {
            #region add collection data, which is based off of the jquery datatables example

            var collection = new List<IBrowser>
            {
                new Browser { Engine = "Gecko", Name = "Firefox 1.0", Platform = "Win 98+ / OSX.2+", Version ="1.7", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Firefox 1.5", Platform = "Win 98+ / OSX.2+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Firefox 2.0", Platform = "Win 98+ / OSX.2+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Firefox 3.0", Platform = "Win 2k+ / OSX.3+", Version ="1.9", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Camino 1.0", Platform = "OSX.2+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Camino 1.5", Platform = "OSX.3+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Netscape 7.2", Platform = "Win 95+ / Mac OS 8.6-9.2", Version ="1.7", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Netscape Browser 8", Platform = "Win 98SE+", Version ="1.7", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Netscape Navigator 9", Platform = "Win 98+ / OSX.2+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.0", Platform = "Win 95+ / OSX.1+", Version ="1", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.1", Platform = "Win 95+ / OSX.1+", Version ="1.1", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.2", Platform = "Win 95+ / OSX.1+", Version ="1.2", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.3", Platform = "Win 95+ / OSX.1+", Version ="1.3", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.4", Platform = "Win 95+ / OSX.1+", Version ="1.4", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.5", Platform = "Win 95+ / OSX.1+", Version ="1.5", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.6", Platform = "Win 95+ / OSX.1+", Version ="1.6", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.7", Platform = "Win 98+ / OSX.1+", Version ="1.7", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Mozilla 1.8", Platform = "Win 98+ / OSX.1+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Seamonkey 1.1", Platform = "Win 98+ / OSX.2+", Version ="1.8", Grade = "A"},
                new Browser { Engine = "Gecko", Name = "Epiphany 2.20", Platform = "Gnome", Version ="1.8", Grade = "A"},
                new Browser { Engine = "KHTML", Name = "Konqureror 3.1", Platform = "KDE 3.1", Version ="3.1", Grade = "C"},
                new Browser { Engine = "KHTML", Name = "Konqureror 3.3", Platform = "KDE 3.3", Version ="3.3", Grade = "A"},
                new Browser { Engine = "KHTML", Name = "Konqureror 3.5", Platform = "KDE 3.5", Version ="3.5", Grade = "A"},
                new Browser { Engine = "Misc", Name = "NetFront 3.1", Platform = "Embedded devices", Version ="-", Grade = "C"},
                new Browser { Engine = "Misc", Name = "NetFront 3.4", Platform = "Embedded devices", Version ="-", Grade = "A"},
                new Browser { Engine = "Misc", Name = "Dillo 0.8", Platform = "Embedded devices", Version ="-", Grade = "X"},
                new Browser { Engine = "Misc", Name = "Links", Platform = "Text only", Version ="-", Grade = "X"},
                new Browser { Engine = "Misc", Name = "Lynx", Platform = "Text only", Version ="-", Grade = "X"},
                new Browser { Engine = "Misc", Name = "IE Mobile", Platform = "Windows Mobile 6", Version ="-", Grade = "C"},
                new Browser { Engine = "Misc", Name = "PSP browser", Platform = "PSP", Version ="-", Grade = "C"},
                new Browser { Engine = "Other browsers", Name = "All others", Platform = "-", Version ="-", Grade = "U"},
                new Browser { Engine = "Presto", Name = "Opera 7.0", Platform = "Win 95+ / OSX.1+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera 7.5", Platform = "Win 95+ / OSX.2+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera 8.0", Platform = "Win 95+ / OSX.2+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera 8.5", Platform = "Win 95+ / OSX.2+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera 9.0", Platform = "Win 95+ / OSX.3+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera 9.2", Platform = "Win 88+ / OSX.3+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera 9.5", Platform = "Win 88+ / OSX.3+", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Opera for Wii", Platform = "Wii", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Nokia N800", Platform = "N800", Version ="-", Grade = "A"},
                new Browser { Engine = "Presto", Name = "Nintendo DS browser", Platform = "Nintendo DS", Version ="8.5", Grade = "C/A<sup>1</sup>"},
                new Browser { Engine = "Tasman", Name = "Internet Explorer 4.5", Platform = "Mac OS 8-9", Version ="-", Grade = "X"},
                new Browser { Engine = "Tasman", Name = "Internet Explorer 5.1", Platform = "Mac OS 7.6-9", Version ="1", Grade = "C"},
                new Browser { Engine = "Tasman", Name = "Internet Explorer 5.2", Platform = "Mac OS 8-X", Version ="1", Grade = "C"},
                new Browser { Engine = "Trident", Name = "Internet Explorer 4.0", Platform = "Win 95+", Version ="4", Grade = "X"},
                new Browser { Engine = "Trident", Name = "Internet Explorer 5.0", Platform = "Win 95+", Version ="5", Grade = "C"},
                new Browser { Engine = "Trident", Name = "Internet Explorer 5.5", Platform = "Win 95+", Version ="5.5", Grade = "A"},
                new Browser { Engine = "Trident", Name = "Internet Explorer 6", Platform = "Win 98+", Version ="6", Grade = "A"},
                new Browser { Engine = "Trident", Name = "Internet Explorer 7", Platform = "Win XP SP2+", Version ="7", Grade = "A"},
                new Browser { Engine = "Trident", Name = "AOL browser (AOL desktop)", Platform = "Win XP", Version ="6", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "Safari 1.2", Platform = "OSX.3", Version ="125.5", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "Safari 1.3", Platform = "OSX.3", Version ="312.8", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "Safari 2.0", Platform = "OSX.4+", Version ="419.3", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "Safari 3.0", Platform = "OSX.4+", Version ="522.1", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "OmniWeb 5.5", Platform = "OSX.4+", Version ="420", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "iPod Touch / iPhone", Platform = "iPod", Version ="420.1", Grade = "A"},
                new Browser { Engine = "Webkit", Name = "S60", Platform = "S60", Version ="413", Grade = "A"}            
            };
            #endregion
            return collection;
        }

        /// <summary>
        /// allows the user to do a global search on anything
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IBrowser> GetGlobalFiltered(string search)
        {
            var searchLower = search.ToLower();

            var result = GetAll().Where(x => x.Engine.ToLower().Contains(searchLower) || x.Grade.ToLower().Contains(searchLower) ||
                                       x.Name.ToLower().Contains(searchLower) || x.Platform.ToLower().Contains(searchLower) ||
                                       x.Version.ToLower().Contains(searchLower)).ToList();

            return result;
        }

        /// <summary>
        /// basics for fake filtering example
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="search"></param>
        /// <param name="ascSort"></param>
        /// <returns></returns>
        public List<IBrowser> GetFiltered(string columnName, string search, bool ascSort)
        {
            var all = GetAll();

            //TODO: use datacontractserializer to determine datamember name to property name

            // we grab the property getter that matches the name, and then from there grab the value from it.

            var result = all.Where(x => x.GetType()
                                          .GetProperties().First(y => y.Name.ToLower() == columnName)
                                          .GetValue(x).ToString().ToLower()
                                          .Contains(search))
                             .OrderByDirection(m => m.GetType()
                                       .GetProperties()
                                       .First(q => q.Name.ToLower() == columnName)
                                       .GetValue(m), ascSort).ToList();

            return result;
        }

        /// <summary>
        /// takes the start and length and cuts down the list by what the datatable requires
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<IBrowser> Reduce(List<IBrowser> collection, int start, int length)
        {
            if (collection == null)
            {
                return new List<IBrowser>();
            }

            collection = collection.Skip(start).ToList();

            collection = collection.Take(length).ToList();

            return collection;
        }
    }
}