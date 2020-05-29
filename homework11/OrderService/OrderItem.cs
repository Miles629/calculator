using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11 {

    public class OrderItem {

        [Key]
        public string Id { get; set; }
        public int Index { get; set; } 
        [ForeignKey("GoodsItemId")]
        public Item Item { get; set; }
        public String Itemname { get => Item != null ? this.Item.Name : ""; }
        public string OrderId { get; set; }
        public int number { get; set; }
        public OrderItem() {
            Id = Guid.NewGuid().ToString();
        }

        public OrderItem(int index, Item goods, int quantity) : this() {
            this.Index = index;
            this.Item = goods;
            this.number = quantity;
        }

        public double TotalPrice {
            get => Item.perPrice * number;
        }

        public override string ToString() {
            return $"[No.:{Index},goods:{Itemname},quantity:{number},totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj) {
            var item = obj as OrderItem;
            return item != null &&
                   Itemname == item.Itemname;
        }

        public override int GetHashCode() {
            int hashCode;
            Int32.TryParse(Id,out hashCode);
            return hashCode;
        }
    }
}