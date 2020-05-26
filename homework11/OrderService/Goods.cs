using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp {
    public class Goods {
        [Key]
        public string GoodID { get; set; }
        public string Name { get; set; }
        public double perPrice { get; set; }

        public Goods() {
        }

        public Goods(string name, double price) {
            GoodID = Guid.NewGuid().ToString();
            Name = name;
            perPrice = price;
        }

        public override bool Equals(object obj) {
            var goods = obj as Goods;
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