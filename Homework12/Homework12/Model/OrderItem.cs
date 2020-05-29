using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12 {

    public class OrderItem {

        [Key]
        public string Id { get; set; }
        public int Index { get; set; } 

        [ForeignKey("GoodsItemId")]
        public Items GoodsItem { get; set; }
        public int number { get; set; }
        public String ItemName { get => this.GoodsItem.Name; }
        public string OrderId { get; set; }

        public OrderItem() {
            Id = Guid.NewGuid().ToString();
        }

        public OrderItem(int index, Items goods, int quantity) : this() {
            this.Index = index;
            this.GoodsItem = goods;
            this.number = quantity;
        }

        public double TotalPrice {
            get => GoodsItem.perPrice * number;
        }

        public override string ToString() {
            return $"[No.:{Index},goods:{ItemName},quantity:{number},totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj) {
            var item = obj as OrderItem;
            return item != null &&
                   ItemName == item.ItemName;
        }

        public override int GetHashCode() {
            int hashCode;
            Int32.TryParse(Id,out hashCode);
            return hashCode;
        }
    }
}