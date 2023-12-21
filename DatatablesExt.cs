    public static class DatatablesExt
    {
        /// <summary>
        /// this converts a datatable to a specified list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTableToModelList<T>(this DataTable table) where T : new()
        {
            return table.AsEnumerable().Select(row =>
            {
                T model = new T();

                foreach (DataColumn column in table.Columns)
                {
                    Debug.Print($"column.ColumnName: {column.ColumnName}");

                    var property = typeof(T).GetProperty(column.ColumnName);
                    if (property != null)
                    {
                        if (row[column] is DBNull || row[column] == DBNull.Value)
                        {
                            property.SetValue(model, null);
                        }
                        else
                        {
                            // Convert the value to the property's type, assuming types match
                            property.SetValue(model, Convert.ChangeType(row[column], property.PropertyType), null);
                        }
                    }
                }

                return model;
            }).ToList();
        }
    }
