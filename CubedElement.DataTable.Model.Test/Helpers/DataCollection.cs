using System;
using System.Collections.Generic;
using CubedElement.DataTable.Contracts;
using Rhino.Mocks;

namespace CubedElement.DataTable.Test.Helpers
{
    public static class DataCollection
    {
        public static IList<IDataTableSerializer> GenerateCollection(int maxColumns = 2, int max = 10)
        {
            var result = new List<IDataTableSerializer>();
            
            var columnName = new List<string>();

            for (var i = 0; i < maxColumns; i++)
            {
                columnName.Add(Guid.NewGuid().ToString());
            }

            for (var i = 0; i < max; i++)
            {
                var objects = new object[maxColumns];

                for (var j = 0; j < maxColumns; j++)
                {
                    objects[j] = Guid.NewGuid().ToString();
                }

                var m = MockRepository.GenerateMock<IDataTableSerializer>();
                m.Stub(x => x.ToObjectArray()).Return(objects);
                m.Stub(x => x.ColumnNames()).Return(columnName);
                
                result.Add(m);    
            }

            return result;
        }
    }
}
