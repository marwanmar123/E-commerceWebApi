using AuthJWT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthJWT.Models
{
    public class Panier : IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly string _panierId;

        public Panier(ApplicationDbContext Db, string PanierId)
        {
            _db = Db;
            _panierId = PanierId;
        }

        public void AddProduct(string Product_Id)
        {
            RowPanier rowPanier = _db.RowPaniers.SingleOrDefault(p => p.PanierId == _panierId && p.ProductId == Product_Id);
            if (rowPanier == null)
            {
                rowPanier = new RowPanier
                {
                    PanierId = _panierId,
                    ProductId = Product_Id,
                    Quantity = 1
                };
                _db.RowPaniers.Add(rowPanier);
            }
            else
            {
                rowPanier.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
