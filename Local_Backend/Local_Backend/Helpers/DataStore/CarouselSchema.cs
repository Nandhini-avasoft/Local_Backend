using Local_Backend.BOs;
using Npgsql;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Local_Backend.Helpers.DataStore
{
    public struct CarouselSchema
    {
        public enum CarouselTable
        {
            [Description("Carousel_datas")]
            data_table
        }
        public enum CarouselFunction
        {
            [Description("SELECT carousel.add_carousel_contents(@_pic, @_title, @_descript,@_carousel_id)")]
            add_carousel_contents,

            [Description("SELECT (carousel.fetch_conditional_carousel_data(@_title,@_descript)).*")]
            fetch_conditional_carousel_data,

            [Description("SELECT carousel.update_carousel_data(@_carousel_id,@_title)")]
            update_carousel_data,

            [Description("SELECT carousel.delete_carousels_data(@_carousel_id)")]
            delete_carousel_data,

            [Description("SELECT (carousel.fetch_carousel_data()).*")]
            fetch_carousel_data,
        }
        public static int add_carousel_contents(CarouselBo carousel)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("User ID=postgres;Password=N@ndhu@2;Host=localhost;Port=5432;Database=postgres;"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(DBOpeartions.ResolveFunction(CarouselFunction.add_carousel_contents), con))
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@_pic", carousel.pic);
                    cmd.Parameters.AddWithValue("@_title", carousel.title);
                    cmd.Parameters.AddWithValue("@_descript", carousel.descript);
                    cmd.Parameters.AddWithValue("@_carousel_id", carousel.carouselId);

                    var reader = cmd.ExecuteReader();
                    return DBOpeartions.CheckNonQueryStatus(reader, con);
                }
            }
        }

        public static ObservableCollection<CarouselBo> fetch_conditional_carousel_data(string title,string descript)
        {
            ObservableCollection<CarouselBo> CarouselList=new ObservableCollection<CarouselBo>();

            using (NpgsqlConnection con = new NpgsqlConnection("User ID=postgres;Password=N@ndhu@2;Host=localhost;Port=5432;Database=postgres;"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(DBOpeartions.ResolveFunction(CarouselFunction.fetch_conditional_carousel_data), con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@_title", title);
                    cmd.Parameters.AddWithValue("@_descript",descript);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CarouselList.Add(new CarouselBo()
                        {
                            pic = reader.IsDBNull(reader.GetOrdinal("pic")) ? null : reader.GetString(reader.GetOrdinal("pic")),
                            title = reader.IsDBNull(reader.GetOrdinal("title")) ? null : reader.GetString(reader.GetOrdinal("title")),
                            descript = reader.IsDBNull(reader.GetOrdinal("descript")) ? null : reader.GetString(reader.GetOrdinal("descript")),
                            carouselId = reader.IsDBNull(reader.GetOrdinal("carousel_id")) ? -1 : reader.GetInt32(reader.GetOrdinal("carousel_id"))
                        });
                    }

                    con.Close();
                }
            }
            return CarouselList;
        }

        public static int update_carousel_data(int carouselId,string title)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("User ID=postgres;Password=N@ndhu@2;Host=localhost;Port=5432;Database=postgres;"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(DBOpeartions.ResolveFunction(CarouselFunction.update_carousel_data), con))
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@_carousel_id",carouselId);
                    cmd.Parameters.AddWithValue("@_title",title);
                    var reader = cmd.ExecuteReader();
                    return DBOpeartions.CheckNonQueryStatus(reader, con);
                }
            }
        }
        public static int delete_carousel_data(int carousel_id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("User ID=postgres;Password=N@ndhu@2;Host=localhost;Port=5432;Database=postgres;"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(DBOpeartions.ResolveFunction(CarouselFunction.delete_carousel_data), con))
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@_carousel_id", carousel_id);
                    var reader = cmd.ExecuteReader();
                    return DBOpeartions.CheckNonQueryStatus(reader, con);
                }
            }
        }

        public static ObservableCollection<CarouselBo> fetch_carousel_data()
        {
           
            ObservableCollection<CarouselBo> CarouselList = new ObservableCollection<CarouselBo>();

            using (NpgsqlConnection con = new NpgsqlConnection("User ID=postgres;Password=N@ndhu@2;Host=localhost;Port=5432;Database=postgres;"))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(DBOpeartions.ResolveFunction(CarouselFunction.fetch_carousel_data), con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CarouselList.Add(new CarouselBo()
                        {
                            pic = reader.IsDBNull(reader.GetOrdinal("pic")) ? null : reader.GetString(reader.GetOrdinal("pic")),
                            title = reader.IsDBNull(reader.GetOrdinal("title")) ? null : reader.GetString(reader.GetOrdinal("title")),
                            descript = reader.IsDBNull(reader.GetOrdinal("descript")) ? null : reader.GetString(reader.GetOrdinal("descript")),
                            carouselId = reader.IsDBNull(reader.GetOrdinal("carousel_id")) ? -1 : reader.GetInt32(reader.GetOrdinal("carousel_id"))
                        });
                    }

                    con.Close();
                    return CarouselList;
                }
            }
            
        }

    }
}
