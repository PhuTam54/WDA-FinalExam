using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinalExam.Data;
using System;
using System.Linq;
using FinalExam.Models;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using NuGet.Packaging.Signing;
using Microsoft.CodeAnalysis;

namespace FinalExam.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new FinalExamContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<FinalExamContext>>()))
        {
            // Look for any movies.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
            var Departments = new Department[]
             {
                new Department
                {
                    DepartmentName = "Default Department",
                    DepartmentCode = "Default",
                    Location = "Default",
                    NumberOfEmployees = 0,
                },
                new Department
                {
                    DepartmentName = "Accounting Department",
                    DepartmentCode = "A",
                    Location = "Hanoi",
                    NumberOfEmployees = 1,
                },
                new Department
                {
                    DepartmentName = "Production Management Department",
                    DepartmentCode = "PM",
                    Location = "Hanoi",
                    NumberOfEmployees = 2,
                },
                new Department
                {
                    DepartmentName = "Human Resources Department",
                    DepartmentCode = "HM",
                    Location = "Saigon",
                    NumberOfEmployees = 1,
                },
                new Department
                {
                    DepartmentName = "IT Department",
                    DepartmentCode = "IT",
                    Location = "Hanoi",
                    NumberOfEmployees = 2,
                }
            };
            foreach (Department s in Departments)
            {
                context.Department.Add(s);
            }
            context.SaveChanges();

            var Users = new User[]
            {
                new User
                {
                    DepartmentId = 2,
                    EmployeeCode = "phutam",
                    Rank = "1",
                    FirstMidName = "Tam",
                    LastName = "Phu",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 5,
                    EmployeeCode = "tranthuy",
                    Rank = "2",
                    FirstMidName = "Thuy",
                    LastName = "Tran",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 3,
                    EmployeeCode = "peter",
                    Rank = "3",
                    FirstMidName = "Peter",
                    LastName = "Parker",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 2,
                    EmployeeCode = "tom",
                    Rank = "4",
                    FirstMidName = "Tom",
                    LastName = "Holland",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 4,
                    EmployeeCode = "ronaldo",
                    Rank = "5",
                    FirstMidName = "Cristiano",
                    LastName = "Ronaldo",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 1,
                    EmployeeCode = "phutam2",
                    Rank = "1",
                    FirstMidName = "Tam",
                    LastName = "Phu",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 1,
                    EmployeeCode = "tranthuy2",
                    Rank = "2",
                    FirstMidName = "Thuy",
                    LastName = "Tran",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 1,
                    EmployeeCode = "peter2",
                    Rank = "3",
                    FirstMidName = "Peter",
                    LastName = "Parker",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 1,
                    EmployeeCode = "tom2",
                    Rank = "4",
                    FirstMidName = "Tom",
                    LastName = "Holland",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 1,
                    EmployeeCode = "ronaldo2",
                    Rank = "5",
                    FirstMidName = "Cristiano",
                    LastName = "Ronaldo",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },

            };
            foreach (User s in Users)
            {
                context.User.Add(s);
            }
            context.SaveChanges();


        }
    }
}