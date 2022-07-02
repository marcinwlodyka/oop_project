using OOP.domain.Model;
using OOP.domain.Services;
using OOP.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EF.Services
{
    public class PizzeriaDBServices : ICrud
    {
        private readonly IDataService<Order> _crudServices;

        public PizzeriaDBServices()
        {
            _crudServices = new GenericDataService<Order>(new PizzeriaDBContextFactory());
        }

        public async Task<Order> AddBrand(string pizzaId, string sizeId, string orderDate, string address)
        {
            try
            {
                if (pizzaId == string.Empty || sizeId == string.Empty || orderDate == string.Empty || address == string.Empty)
                {
                    throw new Exception("Pizza name, size, date and address can't be empty.");
                }
                else
                {
                    Order br = new Order
                    {
                        pizzaId = Convert.ToInt32(pizzaId),
                        sizeId = Convert.ToInt32(sizeId),
                        orderDate = orderDate,
                        address = address
                    };
                    return await _crudServices.Create(br);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                Order delete = await SearchBrandbyID(id);
                return await _crudServices.Delete(delete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ICollection<Order>> ListBrands()
        {
            try
            {
                return (ICollection<Order>)await _crudServices.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Task<Order> SearchBrandbyID(int ID)
        {
            try
            {
                return _crudServices.Get(ID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //public async Task<ICollection<Order>> SearchBrandByName(string stname)
        //{
        //    try
        //    {
        //        var listbrand = await ListBrands();
        //        return listbrand.Where(x => x.stname.StartsWith(stname)).ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);

        //    }
        //}

        public async Task<Order> UpdateBrand(string id, string pizzaId, string sizeId, string orderDate, string address)
        {
            try
            {
                Order br = await SearchBrandbyID(Convert.ToInt32(id));
                br = new Order
                {
                    id = Convert.ToInt32(id),
                    pizzaId = pizzaId != string.Empty ? Convert.ToInt32(pizzaId) : br.pizzaId,
                    sizeId = sizeId != string.Empty ? Convert.ToInt32(sizeId) : br.sizeId,
                    orderDate = orderDate != string.Empty ? orderDate : br.orderDate,
                    address = address != string.Empty ? address : br.address,
                };

                return await _crudServices.Update(br);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
