using System;
using System.Collections.Generic;
using System.Linq;
using ClickHouse.Ado;
using ClickHouse.Net.Entities;

namespace ClickHouse.Net.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var db = new ClickHouseDatabase(
            //    new ClickHouseConnectionSettings("Compress=True;CheckCompressedHash=False;Compressor=lz4;Host=192.168.0.163;Port=9000;User=default;Password=;SocketTimeout=600000;Database=TeasersStat;"),
            //    new ClickHouseCommandFormatter(),
            //    new ClickHouseConnectionFactory(),
            //    null);
            /*
            db.Open();
            db.BackupDatabase("TeasersStat");
            db.Close();
            */
            var f = new ClickHouseCommandFormatter();
            var q = f.CreateTable(new Table
            {
                // Engine = "MergeTree(date, (date, Id, Number, Cost), 8192)",
                Engine = "MergeTree() PARTITION BY toYYYYMM(Timestamp) ORDER BY (Timestamp, Symbol) SETTINGS index_granularity=8192;",
                Name = "BitmexTickTrades",
                Columns = new List<Column>()
                    {
                        new Column("Timestamp", "Date"),                        
                        new Column("TimestampMs", "String"),
                        new Column("Symbol", "String"),
                        new Column("Side", "String"),
                        new Column("Size", "Int64"),
                        new Column("Price", "Float64"),
                        new Column("TickDirection", "String"),
                        new Column("TrdMatchId", "UUID"),
                        new Column("GrossValue", "Int64"),
                        new Column("HomeNotional", "Float64"),
                        new Column("ForeignNotional", "Float64"),
                    }
            });
           // var columns = db.DescribeTable("LastTeasersShows").ToArray();
        }
    }
}
