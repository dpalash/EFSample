using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDBContext modelContext = new TestDBContext();
            //var test = modelContext.EncCells;
            //var encCellsTo = modelContext.EncCells.Include("issuer").Take(5).ToList();

            var cellBos = GetEncCells();

            TestDBContext modelContext1 = new TestDBContext();

            try
            {
                var objissuer = modelContext1.issuers.Take(2).ToList();

                var issuerBo = objissuer.Cast<IssuerBO>().ToList();

                foreach (var item in issuerBo)
                {
                    //item.IssuerShortName += "change";
                }

                modelContext1.SaveChanges();

            }
            catch (Exception ex)
            {

            }

            var issuer = new issuer() { Id = 12, IssuerShortName = "PR", Issuer = "Primar" };// modelContext1.issuers.FirstOrDefault();

            //var cells = modelContext1.EncCells.ToList();//.FirstOrDefault();

            List<EncCell> encCells = new List<EncCell>();

            var enccell = new EncCell();
            enccell.CellName = "AR00010";
            enccell.Description = "AR00010 ours";
            enccell.IsForSale = false;
            //enccell.Issuer3Id = 12;
            enccell.issuer = issuer;// new issuer() { Id = 12, Active = true, Issuer = "Primar", IssuerShortName = "PR" };

            encCells.Add(enccell);

            enccell = new EncCell();
            enccell.CellName = "AR00011";
            enccell.Description = "AR00011 ours";
            enccell.IsForSale = false;
            //enccell.Issuer3Id = 12;
            enccell.issuer = issuer;// new issuer(){ Id = 12, Active = true, Issuer = "Primar", IssuerShortName = "PR" };

            encCells.Add(enccell);

            AddEncCell(encCells, modelContext1);

            Console.ReadLine();
        }

        //public static void AddEncCell(List<EncCell> encCells)// where T : EncCell
        public static void AddEncCell<T>(List<T> encCells, TestDBContext modelContext1) where T : EncCell
        {
            try
            {
                TestDBContext modelContext = modelContext1;// new TestDBContext();

                modelContext.EncCells.AddRange(encCells);

                modelContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public static IEnumerable<IssuerBO> GetEncCells() //where T : EncCell
        {
            try
            {
                TestDBContext modelContext = new TestDBContext();
                var encCells = modelContext.issuers.OfType<issuer>().ToList();

                List<ICloneable> oldList = new List<ICloneable>();
                List<ICloneable> newList = new List<ICloneable>(encCells.Count);
                oldList.ForEach((item) =>
                {
                    newList.Add((ICloneable)item.Clone());
                });

                //var new1 = CloneClass.CloneObject<List<IssuerBO>>(a1);
                //List<IssuerBO> result = encCells.ConvertAll(instance => (IssuerBO)instance);
                return encCells.Cast<IssuerBO>().ToList();
            }
            catch (Exception ex)
            {

            }

            return null;
        }

    }

    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
    public static class CloneClass
    {
        /// <summary>
        /// Clones a object via shallow copy
        /// </summary>
        /// <typeparam name="T">Object Type to Clone</typeparam>
        /// <param name="obj">Object to Clone</param>
        /// <returns>New Object reference</returns>
        public static T CloneObject<T>(this T obj) where T : class
        {
            if (obj == null) return null;
            System.Reflection.MethodInfo inst = obj.GetType().GetMethod("MemberwiseClone",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst != null)
                return (T)inst.Invoke(obj, null);
            else
                return null;
        }
    }
}
