using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Logging;

namespace ERP.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<ERPUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<ERPUser> ERPUser { get; set; }
        //public DbSet<ApplicationRole> ApplicationRole { get; set; }

        public DbSet<City> City { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<FabricType> FabricTypes { get; set; }
        public DbSet<Mill> Mills { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<ConsignmentOrder> ConsignmentOrders { get; set; }
        public DbSet<ConsignmentOrderItem> ConsignmentOrderItem { get; set; }

        public DbSet<Status> Status { get; set; }
        public DbSet<ActionButtons> ActionButtons { get; set; }

        public DbSet<OrderComment> OrderComments { get; set; }

        public DbSet<PaperMillProfile> PaperMillProfile { get; set; }
        public DbSet<PaperMillProfileDetail> PaperMillProfileDetail { get; set; }

        public DbSet<ProductRate> ProductRate { get; set; }
        public DbSet<Designation> Designation { get; set; }

        public DbSet<FabricCode> FabricCodes { get; set; }
        public DbSet<DailyStock> DailyStocks { get; set; }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Receivable> Receivables { get; set; }

        public DbSet<Log> ApplicationLog { get; set; }

        public DbSet<TempAttachment> TempAttachment { get; set; }

        public DbSet<ATTACHMENT> ATTACHMENT { get; set; }
        public DbSet<TRANSACTION> TRANSACTION { get; set; }
        public DbSet<TRANSACTION_ATTACHMENT> TRANSACTION_ATTACHMENT { get; set; }
        public DbSet<TRANSACTION_TYPE> TRANSACTION_TYPE { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedStatus(builder);
            SeedActionButtons(builder);
            SeedRegions(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
            SeedFabricType(builder);
            SeedFabricCodes(builder);
            SeedReports(builder);

            SeedFabrics(builder);

            SeedCitiies(builder);
            SeedDesignations(builder);
            SeedPersons(builder);

            SeedMills(builder);

            SeedProductRates(builder);
        }

        private void SeedProductRates(ModelBuilder builder)
        {
            builder.Entity<ProductRate>().HasData(
                new ProductRate
                {
                    Id = Guid.Parse("43553771-eebd-458f-91bb-efc0f6f5ef3b"),
                    AskingRate = 1111,
                    MinimumRate = 2222,
                    MaximumRate = 3333,
                    FabricId = Guid.Parse("3D71BF60-CE6C-4C87-B271-6F0357C017FB"),
                    IsActive = true,
                },
                new ProductRate
                {
                    Id = Guid.Parse("8d9b8c04-756e-485d-8901-f6ee1dc98072"),
                    AskingRate = 4444,
                    MinimumRate = 5555,
                    MaximumRate = 6666,
                    FabricId = Guid.Parse("CCC3C1A0-4807-4486-B611-C20711B65F66"),
                    IsActive = true,
                },
                new ProductRate
                {
                    Id = Guid.Parse("76b58ec7-5e0d-4868-8c45-c61f4664cb14"),
                    AskingRate = 7777,
                    MinimumRate = 8888,
                    MaximumRate = 9999,
                    FabricId = Guid.Parse("FF9BA921-0B10-4E19-BA50-C54B48C6EF47"),
                    IsActive = true,
                },
                new ProductRate
                {
                    Id = Guid.Parse("3c498c68-ff89-4b83-994c-ca5e36faf9f4"),
                    AskingRate = 0000,
                    MinimumRate = 1122,
                    MaximumRate = 3344,
                    FabricId = Guid.Parse("20653D3A-FFEE-45E8-A346-CA034E43A752"),
                    IsActive = true,
                },
                new ProductRate
                {
                    Id = Guid.Parse("2c14dd42-e9fd-4f38-a7f5-d9b90e090567"),
                    AskingRate = 4455,
                    MinimumRate = 6677,
                    MaximumRate = 8899,
                    FabricId = Guid.Parse("B9134BC6-8456-400E-8457-F3AA75CBEBA4"),
                    IsActive = true,
                }
                );
        }

        private void SeedMills(ModelBuilder builder)
        {
            builder.Entity<Mill>().HasData(
                new Mill
                {
                    Id = Guid.Parse("69ae3e06-2407-4074-b4ab-450200bb3470"),
                    Name = "Ahmad Paper Mill",
                    Code = "07-kar-ahm",
                    MDId = Guid.Parse("BBC84742-4BBF-44D6-BB17-911B82DBFC37"),
                    MangerId = Guid.Parse("E2C71C6B-F141-415B-9A5D-CCB7727AEAA4"),
                    CPMId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    MechanicalId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    CityId = Guid.Parse("93F89299-CFC9-4998-9DDD-09C5583DC8C2"),
                    IsActive = true,
                },
                new Mill
                {
                    Id = Guid.Parse("c4c9feb4-3478-4dfc-ba01-b629c74a76e9"),
                    Name = "Ashraf Paper",
                    Code = "07-kar-ash",
                    MDId = Guid.Parse("BBC84742-4BBF-44D6-BB17-911B82DBFC37"),
                    MangerId = Guid.Parse("E2C71C6B-F141-415B-9A5D-CCB7727AEAA4"),
                    CPMId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    MechanicalId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    CityId = Guid.Parse("93F89299-CFC9-4998-9DDD-09C5583DC8C2"),
                    IsActive = true,
                },
                new Mill
                {
                    Id = Guid.Parse("d862a91a-a3aa-4767-ba1a-92a77606f2b9"),
                    Name = "Aziz Paper",
                    Code = "07-kar-azi",
                    MDId = Guid.Parse("BBC84742-4BBF-44D6-BB17-911B82DBFC37"),
                    MangerId = Guid.Parse("E2C71C6B-F141-415B-9A5D-CCB7727AEAA4"),
                    CPMId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    MechanicalId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    CityId = Guid.Parse("93F89299-CFC9-4998-9DDD-09C5583DC8C2"),
                    IsActive = true,
                },
                new Mill
                {
                    Id = Guid.Parse("e6933b4b-8ece-4791-b5f8-bdf98007cf59"),
                    Name = "ASL",
                    Code = "07-kar-asl",
                    MDId = Guid.Parse("BBC84742-4BBF-44D6-BB17-911B82DBFC37"),
                    MangerId = Guid.Parse("E2C71C6B-F141-415B-9A5D-CCB7727AEAA4"),
                    CPMId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    MechanicalId = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    CityId = Guid.Parse("93F89299-CFC9-4998-9DDD-09C5583DC8C2"),
                    IsActive = true,
                }
                );
        }

        private void SeedPersons(ModelBuilder builder)
        {
            builder.Entity<Person>().HasData(
                new Person
                {
                    Id = Guid.Parse("D2EE36C6-55A6-41E2-B773-4C3A0C18A915"),
                    Name = "Person 1",
                    EmailAddress = "test1@test..com",
                    PrimaryPhone = "1111111",
                    SecondaryPhone = "1111111",
                    IsActive = true,
                },
                new Person
                {
                    Id = Guid.Parse("BBC84742-4BBF-44D6-BB17-911B82DBFC37"),
                    Name = "Person 2",
                    EmailAddress = "test2@test..com",
                    PrimaryPhone = "22222222",
                    SecondaryPhone = "22222222",
                    IsActive = true,
                },
                new Person
                {
                    Id = Guid.Parse("E2C71C6B-F141-415B-9A5D-CCB7727AEAA4"),
                    Name = "Person 3",
                    EmailAddress = "test3@test..com",
                    PrimaryPhone = "333333333",
                    SecondaryPhone = "333333333",
                    IsActive = true,
                },
                new Person
                {
                    Id = Guid.Parse("73EB19F8-F9C5-4A7A-BE14-ED957A70467F"),
                    Name = "Person 4",
                    EmailAddress = "test4@test..com",
                    PrimaryPhone = "444444444",
                    SecondaryPhone = "444444444",
                    IsActive = true,
                }
                );
        }

        private void SeedDesignations(ModelBuilder builder)
        {
            builder.Entity<Designation>().HasData(
                new Designation
                {
                    Id = Guid.Parse("EEE1A096-83EA-4D3F-88EE-1DA7F6615B77"),
                    Name = "MD",
                    Description = "Managing Director",
                    IsActive = true,
                },
                new Designation
                {
                    Id = Guid.Parse("F03ECB13-3F1A-4FBB-B197-591B81CFD6A1"),
                    Name = "CPM",
                    Description = "CPM",
                    IsActive = true,
                },
                new Designation
                {
                    Id = Guid.Parse("53CF0015-26D2-45D0-A2F0-B92087AAA1CD"),
                    Name = "Manager",
                    Description = "Manager",
                    IsActive = true,
                },
                new Designation
                {
                    Id = Guid.Parse("D4DD6404-7C8F-4073-B97C-CCA7959521E8"),
                    Name = "Mechanical",
                    Description = "Mechanical",
                    IsActive = true,
                }
                );
        }

        private void SeedCitiies(ModelBuilder builder)
        {
            builder.Entity<City>().HasData(
            new City
            {
                Id = Guid.Parse("1EEEA024-D7F2-4C83-B5CD-0039DEF1F538"),
                Name = "Karachi",
                Code = "KRI",
                Description = "Karachi",
                IsActive = true,
                RegionId = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0")
            },
            new City
            {
                Id = Guid.Parse("93F89299-CFC9-4998-9DDD-09C5583DC8C2"),
                Name = "Lahore",
                Code = "LHR",
                Description = "Lahore",
                IsActive = true,
                RegionId = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0")
            },
            new City
            {
                Id = Guid.Parse("70F09E81-8E22-4FB5-A3FB-2C07B23390A1"),
                Name = "Gujranwala",
                Code = "GRW",
                Description = "Gujranwala",
                IsActive = true,
                RegionId = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0")
            },
            new City
            {
                Id = Guid.Parse("C63A6AD5-E617-4C77-A160-46FA10B1A47B"),
                Name = "Sialkot",
                Code = "SKT",
                Description = "Sialkot",
                IsActive = true,
                RegionId = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0")
            },
            new City
            {
                Id = Guid.Parse("AF8DB26B-BFFA-452F-9D7E-A5DC67FA1A2B"),
                Name = "Pasrur",
                Code = "PSR",
                Description = "Pasrur",
                IsActive = true,
                RegionId = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0")
            },
            new City
            {
                Id = Guid.Parse("A8B23433-0B69-42FE-A6E7-B93C21A622C6"),
                Name = "Gawadar",
                Code = "GAW",
                Description = "Gawadar",
                IsActive = true,
                RegionId = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0")
            }
            );
        }

        private void SeedReports(ModelBuilder builder)
        {
            builder.Entity<Report>().HasData(

                new Report { Id = Guid.Parse("43383cb7-e170-44e6-936d-baf07818b10a"), Title = "Fabrics Report By Forming Wire", IsActive = true },
                new Report { Id = Guid.Parse("43f41f34-a69c-49ad-9d7b-4bb1ec9d1e55"), Title = "Fabrics Report By Felts", IsActive = true },
                new Report { Id = Guid.Parse("57bace55-524b-4afa-8c31-3ca63099c61e"), Title = "Fabrics Report By Dryer Screen", IsActive = true },
                new Report { Id = Guid.Parse("0b59f606-17b8-4d2d-9131-2c63aefd0718"), Title = "Performance Report By Forming Wire", IsActive = true },
                new Report { Id = Guid.Parse("e436805e-ad6a-4644-b0a8-b67caf3079e9"), Title = "Performance Report By Felts", IsActive = true },
                new Report { Id = Guid.Parse("765b265a-a6f5-4332-af4d-28960bcf41ba"), Title = "Performance Report By Dryer Screen", IsActive = true }
                );
        }

        private void SeedFabrics(ModelBuilder builder)
        {
            builder.Entity<Fabric>().HasData(
                new Fabric
                {
                    Id = Guid.Parse("A35D3703-31EB-40A4-8473-17E4541AD3AA"),
                    Code = "PUF/SL",
                    Description = "Pickup-Felt",
                    IsActive = true,
                    FabricCodeId = Guid.Parse("F704AE37-C067-4D2A-8F58-D74BFC50BAE5"),
                    FabricTypeId = Guid.Parse("E26DC385-2B49-4821-AFCC-4FCE0C95D1D6")
                },
                new Fabric
                {
                    Id = Guid.Parse("3D71BF60-CE6C-4C87-B271-6F0357C017FB"),
                    Code = "FW/DL",
                    Description = "Forming Wire",
                    IsActive = true,
                    FabricCodeId = Guid.Parse("B545B876-130A-40E5-9AEC-1095D8885757"),
                    FabricTypeId = Guid.Parse("43ABCB6D-5814-4906-AEE7-877926C928A1")
                },
                new Fabric
                {
                    Id = Guid.Parse("CCC3C1A0-4807-4486-B611-C20711B65F66"),
                    Code = "FT/LS",
                    Description = "Felt",
                    IsActive = true,
                    FabricCodeId = Guid.Parse("75EB84C2-C26D-42FD-8C24-A2014F87C4B4"),
                    FabricTypeId = Guid.Parse("E614B297-CCCF-43A3-A2E3-43E9C48CDDE4")
                },
                new Fabric
                {
                    Id = Guid.Parse("FF9BA921-0B10-4E19-BA50-C54B48C6EF47"),
                    Code = "PF/SL",
                    Description = "Press Felt",
                    IsActive = true,
                    FabricCodeId = Guid.Parse("6F2EA20A-0E56-4DFA-9952-91859BE12622"),
                    FabricTypeId = Guid.Parse("E26DC385-2B49-4821-AFCC-4FCE0C95D1D6")
                },
                new Fabric
                {
                    Id = Guid.Parse("20653D3A-FFEE-45E8-A346-CA034E43A752"),
                    Code = "MG/SL",
                    Description = "MG Felt",
                    IsActive = true,
                    FabricCodeId = Guid.Parse("FDBFC1EF-759F-4439-9BBD-50036A2EFC5A"),
                    FabricTypeId = Guid.Parse("E26DC385-2B49-4821-AFCC-4FCE0C95D1D6")
                },
                new Fabric
                {
                    Id = Guid.Parse("B9134BC6-8456-400E-8457-F3AA75CBEBA4"),
                    Code = "DS/1.5L",
                    Description = "Dryer Screen",
                    IsActive = true,
                    FabricCodeId = Guid.Parse("7C0E978F-4B34-4666-82CD-48FA14265741"),
                    FabricTypeId = Guid.Parse("BD0E4BD9-840E-4685-97B3-AC085E4AD79F")
                }
                );
        }

        private void SeedFabricType(ModelBuilder builder)
        {
            builder.Entity<FabricType>().HasData(
                new FabricType { Id = Guid.Parse("E26DC385-2B49-4821-AFCC-4FCE0C95D1D6"), Type = "SL", Description = "Single Layer", IsActive = true },
                new FabricType { Id = Guid.Parse("43ABCB6D-5814-4906-AEE7-877926C928A1"), Type = "DL", Description = "Double Layer", IsActive = true },
                new FabricType { Id = Guid.Parse("BD0E4BD9-840E-4685-97B3-AC085E4AD79F"), Type = "1.5L", Description = "1.5 Layer", IsActive = true },
                new FabricType { Id = Guid.Parse("06593449-620A-4427-9E47-598DBDA83A7E"), Type = "MS", Description = "Medium Spiral", IsActive = true },
                new FabricType { Id = Guid.Parse("E614B297-CCCF-43A3-A2E3-43E9C48CDDE4"), Type = "LS", Description = "Large Spiral", IsActive = true }

                );
        }
        private void SeedFabricCodes(ModelBuilder builder)
        {
            builder.Entity<FabricCode>().HasData(
                new FabricCode { Id = Guid.Parse("F704AE37-C067-4D2A-8F58-D74BFC50BAE5"), Code = "PUF", Description = "Pickup-Felt", IsActive = true },
                new FabricCode { Id = Guid.Parse("B545B876-130A-40E5-9AEC-1095D8885757"), Code = "FW", Description = "Forming Wire", IsActive = true },
                new FabricCode { Id = Guid.Parse("75EB84C2-C26D-42FD-8C24-A2014F87C4B4"), Code = "FT", Description = "Felt", IsActive = true },
                new FabricCode { Id = Guid.Parse("6F2EA20A-0E56-4DFA-9952-91859BE12622"), Code = "PF", Description = "Press Felt", IsActive = true },
                new FabricCode { Id = Guid.Parse("FDBFC1EF-759F-4439-9BBD-50036A2EFC5A"), Code = "MG", Description = "MG Felt", IsActive = true },
                new FabricCode { Id = Guid.Parse("7C0E978F-4B34-4666-82CD-48FA14265741"), Code = "DS", Description = "Dryer Screen", IsActive = true }
                );
        }

        private void SeedActionButtons(ModelBuilder builder)
        {
            builder.Entity<ActionButtons>().HasData(

             new ActionButtons { Id = Guid.Parse("af3c18df-1280-4234-8dc5-6ab0ff76048d"), ButtonText = "Create", StatusId = Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("06d9ee9f-3b2c-45e5-bf5e-2a3a5df4df79"), ButtonText = "Save As Draft", StatusId = Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("bd581f44-e950-481a-af53-7880f60cafae"), ButtonText = "Cancel", StatusId = Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63") },

             new ActionButtons { Id = Guid.Parse("fe3717d5-6f91-4518-869f-c8e84d324ffa"), ButtonText = "Approve", StatusId = Guid.Parse("59e07c1d-f068-4a34-2b80-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("4e6032cb-a8a1-48a4-9a14-70d6c4a6ac9c"), ButtonText = "Reject", StatusId = Guid.Parse("59e07c1d-f068-4a34-2b80-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("8a897f19-2605-4726-98a7-ab35ef1eb392"), ButtonText = "On-Hold", StatusId = Guid.Parse("59e07c1d-f068-4a34-2b80-08d64cccfc63") },

             new ActionButtons { Id = Guid.Parse("fa459818-d04e-4fbb-a83c-b56ad66215d0"), ButtonText = "Ship", StatusId = Guid.Parse("5a585ca4-941f-4892-2b81-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("138a4260-c9c5-4612-9eec-90f9e694ad53"), ButtonText = "Update", StatusId = Guid.Parse("5a585ca4-941f-4892-2b81-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("e2e221a4-a449-4a8a-9fde-0987c62f889a"), ButtonText = "Meeting", StatusId = Guid.Parse("5a585ca4-941f-4892-2b81-08d64cccfc63") },

             new ActionButtons { Id = Guid.Parse("d9ce84ca-b4be-474d-99ac-97e95dedad7f"), ButtonText = "Update", StatusId = Guid.Parse("b770f3f8-7b25-478e-2b82-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("61c697fe-0e10-4e9e-9250-fbda8ce5d2ec"), ButtonText = "Close", StatusId = Guid.Parse("b770f3f8-7b25-478e-2b82-08d64cccfc63") },
             new ActionButtons { Id = Guid.Parse("26490b4d-1b1a-470c-8f75-778886f773c0"), ButtonText = "Cancel", StatusId = Guid.Parse("b770f3f8-7b25-478e-2b82-08d64cccfc63") },

             new ActionButtons { Id = Guid.Parse("fa05023a-1255-4734-8330-1290e45001ee"), ButtonText = "Close", StatusId = Guid.Parse("12a02a4a-d055-4812-2b83-08d64cccfc63") },

             new ActionButtons { Id = Guid.Parse("fab89b94-77e3-48ba-b2b8-d63a9adb4302"), ButtonText = "Back", StatusId = Guid.Parse("12a02a4a-d055-4812-2b83-08d64cccfc63") });
        }

        private void SeedStatus(ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status { Id = Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63"), Name = "Created", Description = "Order has been created", IsActive = true },
                new Status { Id = Guid.Parse("59e07c1d-f068-4a34-2b80-08d64cccfc63"), Name = "Submitted", Description = "Order has been submitted for approval", IsActive = true },
                new Status { Id = Guid.Parse("5a585ca4-941f-4892-2b81-08d64cccfc63"), Name = "Approved", Description = "Order has been approved", IsActive = true },
                new Status { Id = Guid.Parse("b770f3f8-7b25-478e-2b82-08d64cccfc63"), Name = "Rejected", Description = "Order has been rejected", IsActive = true },
                new Status { Id = Guid.Parse("12a02a4a-d055-4812-2b83-08d64cccfc63"), Name = "Completed", Description = "Order has been completed", IsActive = true },
                new Status { Id = Guid.Parse("13a02a4a-d055-4812-2b83-08d64cccfc63"), Name = "Close", Description = "Order has been Closed", IsActive = true },
                new Status { Id = Guid.Parse("13b02a4a-d055-4812-2b83-08d64cccfc63"), Name = "Shipped", Description = "Order has been Sjipped", IsActive = true });
        }

        private void SeedUserRoles(ModelBuilder builder)
        {

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "2", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "3", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "4", RoleId = "3" }

                );
        }

        private void SeedUsers(ModelBuilder builder)
        {

            // Admin user
            ERPUser user = new ERPUser
            {
                Id = "1",
                Name = "Sohail",
                Email = "mirza.sohail@hotmail.com",
                NormalizedEmail = "mirza.sohail@hotmail.com",
                DOB = new DateTime(1982, 01, 30),
                UserName = "Sohail",
                NormalizedUserName = "SOHAIL",
                PhoneNumber = "0509705440",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            user.PasswordHash = new PasswordHasher<ERPUser>().HashPassword(user, "Admin@123");
            builder.Entity<ERPUser>().HasData(user);


            // Admin User
            user = new ERPUser
            {
                Id = "2",
                Name = "Waheed",
                Email = "mwasghar@hotmail.com",
                NormalizedEmail = "mmwasghar@hotmail.com",
                DOB = new DateTime(1982, 03, 03),
                UserName = "Waheed",
                NormalizedUserName = "WAHEED",
                PhoneNumber = "+12899381727",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            user.PasswordHash = new PasswordHasher<ERPUser>().HashPassword(user, "Admin@123");
            builder.Entity<ERPUser>().HasData(user);


            // Editor User
            user = new ERPUser
            {
                Id = "3",
                Name = "Editor",
                Email = "Editor@erp.com",
                NormalizedEmail = "Editor@hotmail.com",
                DOB = new DateTime(1982, 03, 03),
                UserName = "Editor",
                NormalizedUserName = "EDITOR",
                PhoneNumber = "+12899381727",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            user.PasswordHash = new PasswordHasher<ERPUser>().HashPassword(user, "Admin@123");
            builder.Entity<ERPUser>().HasData(user);
            // Viewer User
            // Editor User
            user = new ERPUser
            {
                Id = "4",
                Name = "Viewer",
                Email = "Viewer@erp.com",
                NormalizedEmail = "Viewer@hotmail.com",
                DOB = new DateTime(1982, 03, 03),
                UserName = "Viewer",
                NormalizedUserName = "VIEWER",
                PhoneNumber = "+12899381727",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            user.PasswordHash = new PasswordHasher<ERPUser>().HashPassword(user, "Admin@123");
            builder.Entity<ERPUser>().HasData(user);

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", Description = "Admin", CreatedDate = DateTime.Now },
                new ApplicationRole { Id = "2", Name = "Editor", NormalizedName = "EDITOR", Description = "Editor", CreatedDate = DateTime.Now },
                new ApplicationRole { Id = "3", Name = "Viewer", NormalizedName = "VIEWER", Description = "Viewer", CreatedDate = DateTime.Now }
                );
        }

        private void SeedRegions(ModelBuilder builder)
        {
            builder.Entity<Region>().HasData(

                new Region { Id = Guid.Parse("259BDB01-5E73-433D-ABBE-E47CE06D6D4B"), Code = "LHR", Description = "Lahore", IsActive = true, Name = "Lahore", RegionNo = 1 },
                new Region { Id = Guid.Parse("6288ACCF-398A-47A4-B1D9-33F29CDFD521"), Code = "MUL", Description = "Multan", IsActive = true, Name = "Multan", RegionNo = 2 },
                new Region { Id = Guid.Parse("FBF360CD-FB70-44E6-932D-64E12DBCFA39"), Code = "GRW", Description = "Gujranwala", IsActive = true, Name = "Gujranwala", RegionNo = 3 },
                new Region { Id = Guid.Parse("5EC19418-88BD-4D27-A885-02424070AA0B"), Code = "PES", Description = "Peshawar", IsActive = true, Name = "Peshawar", RegionNo = 4 },
                new Region { Id = Guid.Parse("96DB3D6D-4D23-4A28-ADA0-7151BAEEB752"), Code = "SKP", Description = "Sheikhupura", IsActive = true, Name = "Sheikhupura", RegionNo = 5 },
                new Region { Id = Guid.Parse("31B29AFC-3C08-44E1-A2B7-A3B8954C3CAF"), Code = "FSD", Description = "Faislabad", IsActive = true, Name = "Faislabad", RegionNo = 6 },
                new Region { Id = Guid.Parse("0E8C2C9A-F874-48E2-99D7-F4BA65A7FF80"), Code = "SINDH", Description = "Sindh", IsActive = true, Name = "Sindh", RegionNo = 7 },
                new Region { Id = Guid.Parse("C835A328-730C-4EC7-B141-59A861B8EE07"), Code = "MID   ", Description = "Middle", IsActive = true, Name = "Middle", RegionNo = 8 },
                new Region { Id = Guid.Parse("2CF6E3E1-CF0D-4CB1-9E01-9315DFD21AF0"), Code = "MSC", Description = "Msc", IsActive = true, Name = "Msc", RegionNo = 9 }

                );
        }
    }
}
