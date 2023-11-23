using KirillMihailovKt_42_20.Database;
using KirillMihailovKt_42_20.Filters.PrepodFilters;
using KirillMihailovKt_42_20.Interfaces.PrepodInterfaces;
using KirillMihailovKt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KirillMihailovKT_42_20.Tests
{
    public class AppIntegrationTests
    {
        public readonly DbContextOptions<PrepodDbContext> _dbContextOptions;

        public AppIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbContext>().UseInMemoryDatabase(databaseName: "database").Options;
        }
        [Fact]
        public async Task GetPrepodsByKafedraAsync_KT4220_TwoObjects()
        {
            // Arrange
            var ctx = new PrepodDbContext(_dbContextOptions);
            var prepodService = new PrepodService(ctx);

            var academicDegrees = new List<AcademicDegree>
            {
                new AcademicDegree
                {
                    AcademicDegreeName = "Кандидат наук"
                },
                new AcademicDegree
                {
                    AcademicDegreeName = "Доктор наук"
                }
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicDegrees);

            var Kafedra = new List<Kafedra>
            {
                new Kafedra
                {
                    KafedraName = "ИВТ",
                    DateFoundation = new DateTime(2008, 12, 09),
                    PrepodCount = 7
                },
                new Kafedra
                {
                    KafedraName = "КТ",
                    DateFoundation = new DateTime(2006, 11, 02),
                    PrepodCount = 10
                },
                 new Kafedra
                {
                    KafedraName = "РЭА",
                    DateFoundation = new DateTime(2002, 09, 09),
                    PrepodCount = 5
                },
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicDegrees);

            var prepods = new List<Prepod>
            {
                new Prepod
                {
                    FirstName = "qwerty",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    KafedraId = 1,
                    AcademicDegreeId = 1
                },
                new Prepod
                {
                    FirstName = "qwerty2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    KafedraId = 2,
                    AcademicDegreeId = 1
                },
                new Prepod
                {
                    FirstName = "qwerty3",
                    LastName = "asdf3",
                    MiddleName = "zxc3",
                    KafedraId = 1,
                    AcademicDegreeId = 2
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepods);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new PrepodAcademicDegreeFilter
            {
                AcademicDegreeName = "Кандидат наук"
            };
            var prepodsResult = await prepodService.GetPrepodByAcademicDegreeAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, prepodsResult.Length);
        }
    }
}
