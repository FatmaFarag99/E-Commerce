﻿namespace ECommerce
{
    using ECommerce.Common;

    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string NameSecondLanguage { get; set; }
        public string Description { get; set; }
        public string DescriptionSecondLanguage { get; set; }
        public List<Product> Products { get; set; }
    }
}