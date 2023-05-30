using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    internal class ItemSeed
    {
        internal Item[] Items
        {
            get
            {
                return new Item[]
                {
                    new Item { Id = new Guid("13530E69-AEB3-4A44-B6A0-714546093FE7"), Name = "Item 1", UnitPrice = 10.99m },
                    new Item { Id = new Guid("2FA3A5D2-C1F9-48A8-9CE4-CC05C3B739AE"), Name = "Item 2", UnitPrice = 15.99m },
                    new Item { Id = new Guid("9FC6ABEA-0D6D-4168-B147-549F2A64A174"), Name = "Item 3", UnitPrice = 7.99m },
                };
            }
        }
    }
}
