using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12 {
    public class Items {
        [Key]
        public string GoodID { get; set; }
        public string Name { get; set; }
        public double perPrice { get; set; }

        public Items() {
        }

        public Items(string name, double price) {
            GoodID = Guid.NewGuid().ToString();
            Name = name;
            perPrice = price;
        }

        public override bool Equals(object obj) {
            var goods = obj as Items;
            return goods != null &&
                   GoodID == goods.GoodID &&
                   Name == goods.Name;
        }

        public override int GetHashCode() {
            int hashCode;
            Int32.TryParse(GoodID, out hashCode);
            return hashCode;
        }
    }


}