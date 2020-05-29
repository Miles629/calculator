using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11 {
    public class Item {
        [Key]
        public string ItemID { get; set; }
        public string Name { get; set; }
        public double perPrice { get; set; }

        public Item() {
        }

        public Item(string name, double price) {
            ItemID = Guid.NewGuid().ToString();
            Name = name;
            perPrice = price;
        }

        public override bool Equals(object obj) {
            var goods = obj as Item;
            return goods != null &&
                   ItemID == goods.ItemID &&
                   Name == goods.Name;
        }

        public override int GetHashCode() {
            int hashCode;
            Int32.TryParse(ItemID, out hashCode);
            return hashCode;
        }
    }


}