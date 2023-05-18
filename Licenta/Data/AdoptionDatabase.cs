using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Licenta.Models;
using Size = Licenta.Models.Size;

namespace Licenta.Data
{
    public class AdoptionDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AdoptionDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LoginModel>().Wait();
            _database.CreateTableAsync<Employee>().Wait();
            _database.CreateTableAsync<AdoptRequest>().Wait();
            _database.CreateTableAsync<Appointment>().Wait();
            _database.CreateTableAsync<Dog>().Wait();
            _database.CreateTableAsync<Food>().Wait();
            _database.CreateTableAsync<Guest>().Wait();
            _database.CreateTableAsync<MedicalRecord>().Wait();
            _database.CreateTableAsync<Medicine>().Wait();
            _database.CreateTableAsync<Provider>().Wait();
            _database.CreateTableAsync<Room>().Wait();
            _database.CreateTableAsync<Treatment>().Wait();
            _database.CreateTableAsync<Size>().Wait();
            _database.CreateTableAsync<ListSize>().Wait();
            _database.CreateTableAsync<Order>().Wait();
            _database.CreateTableAsync<CardDetail>().Wait();
        }
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
        //Pt angajati 
        public Task<List<Employee>> GetEmployeesAsync()
        {
            return _database.Table<Employee>().ToListAsync();
        }
        public Task<Employee> GetEmployeeAsync(int id)
        {
            return _database.Table<Employee>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveEmployeeAsync(Employee emp)
        {
            if (emp.ID != 0)
            {
                return _database.UpdateAsync(emp);
            }
            else
            {
                return _database.InsertAsync(emp);
            }
        }
        public Task<int> DeleteEmployeeAsync(Employee emp)
        {
            return _database.DeleteAsync(emp);
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

        //Pt programari
        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }
        public Task<Appointment> GetAppointmentAsync(int id)
        {
            return _database.Table<Appointment>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveAppointmentAsync(Appointment appointment)
        {
            if (appointment.ID != 0)
            {
                return _database.UpdateAsync(appointment);
            }
            else
            {
                return _database.InsertAsync(appointment);
            }
        }
        public Task<int> DeleteAppointmentAsync(Appointment appointment)
        {
            return _database.DeleteAsync(appointment);
        }

        //Pt caini
        public Task<List<Dog>> GetDogsAsync()
        {
            return _database.Table<Dog>().ToListAsync();
        }
        public Task<Dog> GetDogAsync(int id)
        {
            return _database.Table<Dog>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveDogAsync(Dog dog)
        {
            if (dog.ID != 0)
            {
                return _database.UpdateAsync(dog);
            }
            else
            {
                return _database.InsertAsync(dog);
            }
        }
        public Task<int> DeleteDogAsync(Dog dog)
        {
            return _database.DeleteAsync(dog);
        }

        //Pt hrana
        /*public Task<List<Food>> GetFoodsAsync()
        {
            return _database.Table<Food>().ToListAsync();
        }
        public Task<Food> GetFoodAsync(int id)
        {
            return _database.Table<Food>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveFoodAsync(Food food)
        {
            if (food.ID != 0)
            {
                return _database.UpdateAsync(food);
            }
            else
            {
                return _database.InsertAsync(food);
            }
        }
        public Task<int> DeleteFoodAsync(Food food)
        {
            return _database.DeleteAsync(food);
        }*/

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

        //Pt furnizori
        public Task<List<Provider>> GetProvidersAsync()
        {
            return _database.Table<Provider>().ToListAsync();
        }
        public Task<Provider> GetProviderAsync(int id)
        {
            return _database.Table<Provider>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveProviderAsync(Provider provider)
        {
            if (provider.ID != 0)
            {
                return _database.UpdateAsync(provider);
            }
            else
            {
                return _database.InsertAsync(provider);
            }
        }
        public Task<int> DeleteProviderAsync(Provider provider)
        {
            return _database.DeleteAsync(provider);
        }

        //Pt camere
        public Task<List<Room>> GetRoomsAsync()
        {
            return _database.Table<Room>().ToListAsync();
        }
        public Task<Room> GetRoomAsync(int id)
        {
            return _database.Table<Room>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveRoomAsync(Room room)
        {
            if (room.ID != 0)
            {
                return _database.UpdateAsync(room);
            }
            else
            {
                return _database.InsertAsync(room);
            }
        }
        public Task<int> DeleteRoomAsync(Room room)
        {
            return _database.DeleteAsync(room);
        }

        //Pt tratamente
        public Task<List<Treatment>> GetTreatmentsAsync()
        {
            return _database.Table<Treatment>().ToListAsync();
        }
        public Task<Treatment> GetTreatmentAsync(int id)
        {
            return _database.Table<Treatment>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveTreatmentAsync(Treatment treatment)
        {
            if (treatment.ID != 0)
            {
                return _database.UpdateAsync(treatment);
            }
            else
            {
                return _database.InsertAsync(treatment);
            }
        }
        public Task<int> DeleteTreatmentAsync(Treatment treatment)
        {
            return _database.DeleteAsync(treatment);
        }

        //Pt size
        public Task<int> SaveSizeAsync(Size sz)
        {
            if (sz.ID != 0)
            {
                return _database.UpdateAsync(sz);
            }
            else
            {
                return _database.InsertAsync(sz);
            }
        }
        public Task<int> DeleteSizeAsync(Size sz)
        {
            return _database.DeleteAsync(sz);
        }
        public Task<List<Size>> GetSizesAsync()
        {
            return _database.Table<Size>().ToListAsync();
        }


        public Task<int> SaveListSizeAsync(ListSize lists)
        {
            if (lists.ID != 0)
            {
                return _database.UpdateAsync(lists);
            }
            else
            {
                return _database.InsertAsync(lists);
            }
        }
        public Task<List<Size>> GetListSizesAsync(int dogid)
        {
            return _database.QueryAsync<Size>(
            "select S.ID, S.Description from Size S"
            + " inner join ListSize LS"
            + " on S.ID = LS.SizeID where LS.DogID = ?",
            dogid);
        }
    }
}
   