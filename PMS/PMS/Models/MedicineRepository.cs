using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace PMS.Models
{
	public static class MedicineRepository
	{
		private static List<Medicine> _Medicines = new List<Medicine>()
		{
			new Medicine(){MedicineId=1,Name="Sinex",GroupId=1,Price=90,Quantity=200,Description="Common cold",ExpiryDate=new DateOnly(2025,04,2)},
			new Medicine(){MedicineId=2,Name="Flexon",GroupId=1,Price=30,Quantity=300,Description="Fever,Headache",ExpiryDate=new DateOnly(2025,04,2)},
			new Medicine(){MedicineId=3,Name="Dialute",GroupId=3,Price=150,Quantity=150,Description="Cough,Chest Pain",ExpiryDate=new DateOnly(2025,04,2)},
			new Medicine(){MedicineId=4,Name="Lactogen",GroupId=2,Price=200,Quantity=500,Description="Baby vitamin", ExpiryDate = new DateOnly(2025, 04, 2)}
		};
		public static void AddMedicine(Medicine medicine)
		{
			if (_Medicines != null && _Medicines.Count()>0)
			{
				var maxId=_Medicines.Max(m => m.MedicineId);
				medicine.MedicineId = maxId + 1;
			}
			else
			{
				medicine.MedicineId = 1;
			}
			if(_Medicines == null)
			{
				_Medicines= new List<Medicine>();
			}
			_Medicines.Add(medicine);
			
		}
		public static List<Medicine> GetMedicines(bool loadGroup=false)
		{
			if(!loadGroup)
			{
				return _Medicines;
			}
			else
			{
				if(_Medicines!=null && _Medicines.Count()>0)
				{
					_Medicines.ForEach(m =>
					{
						if(m.GroupId.HasValue)
						{
							m.Group=GroupRepository.GetGroupById(m.GroupId.Value);
						}
					});
                }
				return _Medicines??new List<Medicine>();
			}

		}
		public static Medicine? GetMedicineById(int id,bool loadGroup = false)
		{
			var medicine=_Medicines.FirstOrDefault(x=>x.MedicineId==id);
			if (medicine != null)
			{
				var med=new Medicine() 
				{
					MedicineId= id,
					Name=medicine.Name,
					Description=medicine.Description,
					Price=medicine.Price,
					GroupId=medicine.GroupId,
					Quantity=medicine.Quantity,
					ExpiryDate=medicine.ExpiryDate,
				};
				if(loadGroup && med.GroupId.HasValue)
				{
					med.Group = GroupRepository.GetGroupById(med.GroupId.Value);
				}
				return med;
			}
			return null;

		}
		public static void UpdateMedicineById(int id, Medicine medicine)
		{
			if(id!=medicine.MedicineId) { return; }
			var medicineToUpdate=_Medicines.FirstOrDefault(x=>x.MedicineId==id);
			if (medicineToUpdate != null)
			{
				medicineToUpdate.Name = medicine.Name;
				medicineToUpdate.Price = medicine.Price;
				medicineToUpdate.Quantity = medicine.Quantity;
				medicineToUpdate.Description = medicine.Description;
				medicineToUpdate.GroupId = medicine.GroupId;
				medicineToUpdate.ExpiryDate = medicine.ExpiryDate;
			}
		}
		public static void DeleteMedicineById(int id)
		{
			var medicine=_Medicines.FirstOrDefault(x=>x.MedicineId==id);
			if (medicine != null)
			{
				_Medicines.Remove(medicine);
			}
		}

	}
}
