using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Licenta.Models;

namespace Licenta.Data
{
    public class AdoptionDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AdoptionDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LoginModel>().Wait();
            _database.CreateTableAsync<AdoptRequest>().Wait();
            _database.CreateTableAsync<Guest>().Wait();
            _database.CreateTableAsync<MedicalRecord>().Wait();
            _database.CreateTableAsync<Medicine>().Wait();
            _database.CreateTableAsync<Order>().Wait();
            _database.CreateTableAsync<CardDetail>().Wait();
        }
        //pt payment
        public Task<int> SaveCardDetail(CardDetail card)
        {
            if (card.ID != 0)
            {
                return _database.UpdateAsync(card);
            }
            else
            {
                return _database.InsertAsync(card);
            }
        }
        public Task<List<CardDetail>> GetCardDetailsAsync()
        {
            return _database.Table<CardDetail>().ToListAsync();
        }
        public Task<int> DeleteCardAsync(CardDetail card)
        {
            return _database.DeleteAsync(card);
        }
        public Task<CardDetail> GetCardDetailAsync(int id)
        {
            return _database.Table<CardDetail>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveOrder(Order order)
        {
            if (order.ID != 0)
            {
                return _database.UpdateAsync(order);
            }
            else
            {
                return _database.InsertAsync(order);
            }
        }
        public Task<int> DeleteOrderAsync(Order order)
        {
            return _database.DeleteAsync(order);
        }
        //pt orders
        public Task<List<Order>> GetOrdersAsync()
        {
            return _database.Table<Order>().ToListAsync();
        }
        public Task<Order> GetOrderAsync(int id)
        {
            return _database.Table<Order>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveUserDataAsync(LoginModel loginData)
        {
            return _database.UpdateAsync(loginData);
        }

        // pt pagina de profil
        public Task<LoginModel> RetrieveDataFromDatabase(string identifier)
        {
            var result = _database.Table<LoginModel>().Where(x => x.UserName == identifier).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    
        //Pt logare
        public Task<LoginModel> GetLoginDataAsync(string userName)
        {
            return _database.Table<LoginModel>()
                            .Where(i => i.UserName == userName)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLoginDataAsync(LoginModel loginData)
        {
            return _database.InsertAsync(loginData);
        }
       
        //Pt cereri adoptie
        public Task<List<AdoptRequest>> GetAdoptionRequestsAsync()
        {
            return _database.Table<AdoptRequest>().ToListAsync();
        }
        public Task<AdoptRequest> GetAdoptionRequestAsync(int id)
        {
            return _database.Table<AdoptRequest>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveAdoptionRequestAsync(AdoptRequest adoption)
        {
            if (adoption.ID != 0)
            {
                return _database.UpdateAsync(adoption);
            }
            else
            {
                return _database.InsertAsync(adoption);
            }
        }
        public Task<int> DeleteAdoptionRequestAsync(AdoptRequest adoption)
        {
            return _database.DeleteAsync(adoption);
        }

        //Pt vizitatori
        public Task<List<Guest>> GetGuestsAsync()
        {
            return _database.Table<Guest>().ToListAsync();
        }
        public Task<Guest> GetGuestAsync(int id)
        {
            return _database.Table<Guest>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveGuestAsync(Guest guest)
        {
            if (guest.ID != 0)
            {
                return _database.UpdateAsync(guest);
            }
            else
            {
                return _database.InsertAsync(guest);
            }
        }
        public Task<int> DeleteGuestAsync(Guest guest)
        {
            return _database.DeleteAsync(guest);
        }

        //Pt fise medicale
        public Task<List<MedicalRecord>> GetMedicalRecordsAsync()
        {
            return _database.Table<MedicalRecord>().ToListAsync();
        }
        public Task<MedicalRecord> GetMedicalRecordAsync(int id)
        {
            return _database.Table<MedicalRecord>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveMedicalRecordAsync(MedicalRecord medical)
        {
            if (medical.ID != 0)
            {
                return _database.UpdateAsync(medical);
            }
            else
            {
                return _database.InsertAsync(medical);
            }
        }
        public Task<int> DeleteMedicalRecordAsync(MedicalRecord medical)
        {
            return _database.DeleteAsync(medical);
        }

        //Pt medicamente
        public Task<List<Medicine>> GetMedicinesAsync()
        {
            return _database.Table<Medicine>().ToListAsync();
        }
        public Task<Medicine> GetMedicineAsync(int id)
        {
            return _database.Table<Medicine>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveMedicineAsync(Medicine medicine)
        {
            if (medicine.ID != 0)
            {
                return _database.UpdateAsync(medicine);
            }
            else
            {
                return _database.InsertAsync(medicine);
            }
        }
        public Task<int> DeleteMedicineAsync(Medicine medicine)
        {
            return _database.DeleteAsync(medicine);
        }
    }
}
   