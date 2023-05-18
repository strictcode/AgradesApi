using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Agrades.Data.Seeds;

public class CategorySeed
{
    public static async Task SeedAync(
        IClock clock,
        AppDbContext dbContext
        )
    {

        if (!dbContext.Raso.Any())
        {
            var xDoc = XDocument.Load(@"..\Agrades.Data\bin\Debug\net7.0\Seeds\CategorySeedFiles\RASO.xml");
            var veta = xDoc.Root.Elements("veta");
            foreach (var item in veta)
            {
                await dbContext.Raor.AddAsync(new Raor
                {
                    Name = item.Element("TXT").Value.ToString(),
                    Code = item.Element("KOD").Value.ToString()
                });
            }


        }
        if(!dbContext.Rauj.Any())
        {
            var xDoc = XDocument.Load(@"..\Agrades.Data\bin\Debug\net7.0\Seeds\CategorySeedFiles\RAUJ.xml");
            var veta = xDoc.Root.Elements("veta");
            foreach (var item in veta)
            {
                await dbContext.Raor.AddAsync(new Raor
                {
                    Name = item.Element("TXT").Value.ToString(),
                    Code = item.Element("KOD").Value.ToString()
                });
            }

        }
        if(!dbContext.Raor.Any())
        {
            var xDoc = XDocument.Load(@"..\Agrades.Data\bin\Debug\net7.0\Seeds\CategorySeedFiles\RAOR.xml");
            var veta = xDoc.Root.Elements("veta");
            foreach (var item in veta)
            {
                await dbContext.Raor.AddAsync(new Raor
                {
                    Name = item.Element("TXT").Value.ToString(),
                    Code = item.Element("KOD").Value.ToString()
                });
            }

        }
        if (!dbContext.Rast.Any())
        {
            var xDoc = XDocument.Load(@"..\Agrades.Data\bin\Debug\net7.0\Seeds\CategorySeedFiles\RAST.xml");
            var veta = xDoc.Root.Elements("veta");
            foreach (var item in veta)
            {
                await dbContext.Rast.AddAsync(new Rast
                {
                    Name = item.Element("TXT").Value.ToString(),
                    Code = item.Element("KOD").Value.ToString()
                });
            }

        }

        await dbContext.SaveChangesAsync();


    }
}
