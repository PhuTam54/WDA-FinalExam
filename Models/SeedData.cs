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
                    DepartmentName = "Accounting Department",
                    DepartmentCode = "Description For Group1's Department",
                    Location = "Hanoi",
                    NumberOfEmployees = 1,
                },
                new Department
                {
                    DepartmentName = "Production Management Department",
                    DepartmentCode = "Description For Group2's Department",
                    Location = "Hanoi",
                    NumberOfEmployees = 2,
                },
                new Department
                {
                    DepartmentName = "Human Resources Department",
                    DepartmentCode = "Description For Department number 3",
                    Location = "Saigon",
                    NumberOfEmployees = 1,
                },
                new Department
                {
                    DepartmentName = "IT Department",
                    DepartmentCode = "Description For Department number 4",
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
                    DepartmentId = 1,
                    EmployeeCode = "phutam",
                    Rank = "1",
                    FirstMidName = "Tam",
                    LastName = "Phu",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 4,
                    EmployeeCode = "tranthuy",
                    Rank = "23",
                    FirstMidName = "Thuy",
                    LastName = "Tran",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 2,
                    EmployeeCode = "peter",
                    Rank = "5",
                    FirstMidName = "Peter",
                    LastName = "Parker",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 1,
                    EmployeeCode = "tom",
                    Rank = "7",
                    FirstMidName = "Tom",
                    LastName = "Holland",
                    Avatar = "https://img.meta.com.vn/Data/image/2021/09/22/anh-meo-cute-de-thuong-dang-yeu-42.jpg",
                },
                new User
                {
                    DepartmentId = 3,
                    EmployeeCode = "ronaldo",
                    Rank = "9",
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