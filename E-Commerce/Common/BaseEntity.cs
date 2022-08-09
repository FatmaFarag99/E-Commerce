﻿namespace ECommerce.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameSecondLanguage { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] ConcurrencyStamp { get; set; }
        public int DisplayOrder { get; set; }
    }
}
