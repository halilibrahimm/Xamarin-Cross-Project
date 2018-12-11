using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using XamarinUcuncuHafta.Utility;
using System.Linq;

namespace XamarinUcuncuHafta.Data
{
    public class MVAFactory
    {
        public class MVA
        {
            public string Title { get; set; }
            public string ImageUrl { get; set; }
            public string Description { get; set; }
            public DateTime PublishDate { get; set; }


        }
        
        public static IList<MVA> MVAData { get; set; }

       
       static MVAFactory()
        {
            MVAData = new ObservableCollection<MVA>
            {
                new MVA
            {
                Title = "Halil ibrahim yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2018, 6, 8),
                ImageUrl = "halil.png",
            },
            new MVA
            {
                Title = "veli yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2014, 7, 8),
                ImageUrl = "veli.png"
            },

            new MVA
            {
                Title = "ali yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2013, 6, 9),
                ImageUrl = "ali.png",
            },

            new MVA
            {
                Title = "ulvi yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2008, 6, 8),
                ImageUrl = "ulvi.png"
            },

            new MVA
            {
                Title = "sadi yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2015, 4, 8),
                ImageUrl = "sadi.png"
            },

            new MVA
            {
                Title = "galip yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2012, 6, 8),
                ImageUrl = "galip.png"
            },

            new MVA
            {
                Title = "sırrı yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2018, 4, 7),
                ImageUrl = "sirri.png"
            },

            new MVA
            {
                Title = "ozi yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2016, 2, 8),
                ImageUrl = "ozi.png"
            },

            new MVA
            {
                Title = "sadık yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2013, 6, 8),
                ImageUrl = "sadik.png"
            },

            new MVA
            {
                Title = "hakan yılmaz",
                Description = "Bilgisayar Mühendisi",
                PublishDate = new DateTime(2078, 6, 8),
                ImageUrl = "hakan.png"
            },
        };


            
        }
        public static IList<MVA> MVADataWithGrouping { get; set; }
        public static ObservableCollection<Grouping<string, MVA>>
            BindingWithGrouping(string searchText="")
        {
            var result = MVAData;
            if (!string.IsNullOrEmpty(searchText) && searchText.Length>3)
            {
                result = result.Where(x => x.Title.ToLower().StartsWith(searchText.ToLower())).ToList();
            }
            var list = new ObservableCollection<Grouping<string, MVA>>
                (result.OrderBy(c => c.Title).GroupBy(c => c.Title[0].ToString()).Select(k => new Grouping<string, MVA>(k.Key, k)));
            return list;
        }

    }

    
}
