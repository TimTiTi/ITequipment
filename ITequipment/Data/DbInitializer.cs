using ITequipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITequipment.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any data, abort seed if found
            if (context.Locations.Any() ||
                context.Rooms.Any() ||
                context.Hardwares.Any() ||
                context.Owners.Any() ||
                context.Softwares.Any() ||
                context.Brands.Any() ||
                context.HW_SW.Any())
                return;   
            

            var locations = new Location[]
            {
                new Location{ Address="Kopilica 7", Place="Split", Country="Croatia" },
                new Location{ Address="Antuna Mihanovića 17", Place="Zagreb", Country="Croatia" },
                new Location{ Address="Svetog leopolda Bogdana Madića 42", Place="Osijek", Country="Croatia" }
            };

            foreach (var location in locations)
            {
                context.Locations.Add(location);
            }
            context.SaveChanges();


            var rooms = new Room[]
            {
                new Room{ Name="ST01", Purpose="IT laboratorij", Floor=0, Size= 50,LocationId=1   },
                new Room{ Name="ST02", Purpose="Laboratorij za elektroniku", Floor=0, Size= 35,LocationId=1   },
                new Room{ Name="ST03", Purpose="Laboratorij za elektroniku", Floor=0, Size= 35,LocationId=1   },
                new Room{ Name="ST04", Floor=0, Size= 70,LocationId=1   },
                new Room{ Name="ST11", Floor=1, Size= 70,LocationId=1 , Purpose="Laboratorij za sve studije" },
                new Room{ Name="ZG01", Purpose="IT laboratorij", Floor=0, Size= 50,LocationId=1   },
                new Room{ Name="ZG02", Purpose="Laboratorij za elektroniku", Floor=0, Size= 35,LocationId=1   },
                new Room{ Name="ZG03", Purpose="Laboratorij za elektroniku", Floor=0, Size= 35,LocationId=1   },
                new Room{ Name="ZG04", Floor=0, Size= 70,LocationId=1   },
                new Room{ Name="ZG11", Floor=1, Size= 70,LocationId=1 , Purpose="Laboratorij za sve studije" }                
            };

            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges();

            var brands = new Brand[]
            {
                new Brand{ Name="Microsoft", ContactFullName="Adam Spencer", Email="adam.spencer@microsoft.com,", WebPage="https://www.microsoft.com"},
                new Brand{ Name="Adobe", ContactFullName="Katerina Sandler", Email="Katerina.Sandler@adobe.com,", WebPage="https://www.adobe.com"},
                new Brand{ Name="Google", ContactFullName="Phill Collins", Phone= "+235 18 523 1234", WebPage="https://www.google.com"},
                new Brand{ Name="Apple", ContactFullName="Herkulies Lu", Phone= "+305 22 523 1234", WebPage="https://www.apple.com"},
                new Brand{ Name="Nvidia", WebPage="https://www.nvidia.com"},
                new Brand{ Name="ADM"},
                new Brand{ Name="Gigabyte", Email="info@Gigabyte.com,", WebPage="https://www.gigabyte.com"},
                new Brand{ Name="IBM", Email="info@ibm.com,", WebPage="https://www.ibm.com"},
                new Brand{ Name="Logitech", Email="info@logitech.com,", WebPage="https://www.ibm.com"},
                new Brand{ Name="Dell"},
                new Brand{ Name="HP"},
                new Brand{ Name="LG"},
            };

            foreach (var brand in brands)
            {
                context.Brands.Add(brand);
            }
            context.SaveChanges();

            var owners = new Owner[]
            {
                new Owner{ FullName="Sveučilišni centar za stručne studije", Email="oss@unist.hr", Phone="+38521346886" },
                new Owner{ FullName="Sveučilište u Splitu", },
            };

            foreach (var owner in owners)
            {
                context.Owners.Add(owner);
            }
            context.SaveChanges();

            var softwares = new Software[]
            {
                new Software{ BrandId=1, LicenceType=LicenceType.Proprietary, Name="Visual Studio", Purpose="Za progamiranje u C#, web development, C/C++"  },
                new Software{ BrandId=3, LicenceType=LicenceType.Protective, Name="Google drive" },
                new Software{ LicenceType=LicenceType.Protective, Name="Statictica" },
                new Software{ BrandId=1, LicenceType=LicenceType.Proprietary, Name="Windows" },
                new Software{ BrandId=1, LicenceType=LicenceType.Proprietary, Name="Office" },
                new Software{ BrandId=1, LicenceType=LicenceType.Proprietary, Name="Azure" },
                new Software{ LicenceType=LicenceType.PublicDomain, Name="Linux Ubuntu" },
                new Software{ LicenceType=LicenceType.PublicDomain, Name="Notepad++" },
            };

            foreach (var software in softwares)
            {
                context.Softwares.Add(software);
            }
            context.SaveChanges();

            var hardwares = new Hardware[]
            {
                new Hardware{ RoomId=1, Name="Monitor-17-01", Specs="17\"", Condition=Condition.Poor, BrandId=12, AcquiredDate=DateTime.Parse("2015-09-01"), Serial="SDUIH3289D", OwnerId=1 },
                new Hardware{ RoomId=1, Name="Monitor-24-01", Specs="24\"", Condition=Condition.Excelent, BrandId=12, AcquiredDate=DateTime.Parse("2018-09-01"), Serial="S123DUADSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=1, Name="Monitor-18-01", Specs="18\"", Condition=Condition.Excelent, BrandId=12, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=1, Name="PC01", Specs="Intel i7, Nvidia 1060", Condition=Condition.Excelent, BrandId=10, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=1, Name="PC02", Specs="Intel i7, Nvidia 1060", Condition=Condition.Excelent, BrandId=10, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=1, Name="PC03", Specs="Intel i7, Nvidia 1060", Condition=Condition.Excelent, BrandId=10, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },

                new Hardware{ RoomId=2, Name="Monitor-17-02", Specs="17\"", Condition=Condition.Poor, BrandId=12, AcquiredDate=DateTime.Parse("2015-09-01"), Serial="SDUIH3289D", OwnerId=1 },
                new Hardware{ RoomId=2, Name="Monitor-24-02", Specs="24\"", Condition=Condition.Excelent, BrandId=12, AcquiredDate=DateTime.Parse("2018-09-01"), Serial="S123DUADSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=2, Name="Monitor-18-02", Specs="18\"", Condition=Condition.Excelent, BrandId=12, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=2, Name="PC04", Specs="Intel i7, Nvidia 1060", Condition=Condition.Excelent, BrandId=10, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=2, Name="PC05", Specs="Intel i7, Nvidia 1060", Condition=Condition.Excelent, BrandId=10, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
                new Hardware{ RoomId=2, Name="PC06", Specs="Intel i7, Nvidia 1060", Condition=Condition.Excelent, BrandId=10, AcquiredDate=DateTime.Parse("2017-10-01"), Serial="S123DSFIH3289D", OwnerId=1 },
            };

            foreach (var hardware in hardwares)
            {
                context.Hardwares.Add(hardware);
            }
            context.SaveChanges();

            var hw_sws = new HW_SW[]
            {
                new HW_SW{ HardwareId=4, SoftwareId=4, Version="10.0.1234", Status=Status.Active },
                new HW_SW{ HardwareId=4, SoftwareId=5, Version="19.0.123", Status=Status.Active },
                new HW_SW{ HardwareId=4, SoftwareId=1, Version="19.0.3", Status=Status.Active },
                new HW_SW{ HardwareId=5, SoftwareId=4, Version="10.0.1234", Status=Status.Active },
                new HW_SW{ HardwareId=5, SoftwareId=5, Version="19.0.123", Status=Status.Active },
                new HW_SW{ HardwareId=5, SoftwareId=1, Version="19.0.3", Status=Status.Active },
                new HW_SW{ HardwareId=5, SoftwareId=8, Version="10.0.1234", Status=Status.Active },
                new HW_SW{ HardwareId=6, SoftwareId=4, Version="12.0.1234", Status=Status.Active },
                new HW_SW{ HardwareId=6, SoftwareId=5, Version="44.0.123", Status=Status.Active },
                new HW_SW{ HardwareId=6, SoftwareId=1, Version="23.0.3", Status=Status.Active },
                new HW_SW{ HardwareId=10, SoftwareId=8, Version="3.0.123", Status=Status.Active },
                new HW_SW{ HardwareId=11, SoftwareId=8, Version="3.0.3", Status=Status.Active },
            };

            foreach (var hw_sw in hw_sws)
            {
                context.HW_SW.Add(hw_sw);
            }
            context.SaveChanges();
        }
    }
}
