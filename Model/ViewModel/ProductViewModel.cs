﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductViewModel
    {
        public long ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string MetaTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CategoryName { get; set; }
        public string CategoryMetaTitle { get; set; }
    }
}
