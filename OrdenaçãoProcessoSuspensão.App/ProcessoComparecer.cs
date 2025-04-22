using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaçãoProcessoSuspensão.App
{
    internal class ProcessoComparecer : IComparer<ProcessoSuspensaoDto>
    {
        public int Compare(ProcessoSuspensaoDto x, ProcessoSuspensaoDto y)//X segundo elemento da lista e y o primeiro
        {

            if (x.ModeloOrdem > y.ModeloOrdem)
                return 1;

            if (x.ModeloOrdem < y.ModeloOrdem)
                return -1;

            else
                return 0;
        }

        public int CompareTo(ProcessoSuspensaoDto suspensaoDto)
        {
            if (suspensaoDto.Modelo.Equals("CAPA"))
            {
                return 0;
            }

            return -1;
        
        }
    }
}

/*
 * //if (object.ReferenceEquals(x, y))
            //{
            //    return 0;
            //}
            //if (x == null)
            //{
            //    return -1;
            //}
            //if (y == null)
            //{
            //    return 1;
            //}
            //if (x.Modelo.CompareTo(y.Modelo).Equals("CAPA-PSDD"))
            if (x.Modelo.Equals("CAPA-PSDD") || y.Modelo.Equals("CAPA-PSDD"))
            {
                return -1; // x.Modelo.CompareTo(y.Modelo);
            }
            else if ((x.Modelo.Equals( "NOTIF-PSDD-1AUTO")) && !y.Modelo.Equals("CAPA-PSDD")  )
            {
                return -1;
            }
            else if (string.Compare(x.Modelo, "CAPA-PSDD") >= 0)
            {
                return -1;
            }
            else if (x.Modelo.CompareTo(y.Modelo).Equals("NOTIF-PSDD-MAIS-AUTOS"))
            {
                return -1;
            }
            else
            {
                //if (x.Modelo.Equals("CAPA-PSDD") || y.Modelo.Equals("CAPA-PSDD"))
                //{
                //    return -1;
                //}
                //if (x.Modelo.Equals("NOTIF-PSDD-1AUTO") || y.Modelo.Equals("NOTIF-PSDD-1AUTO"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("NOTIF-PSDD-MAIS-AUTOS") || y.Modelo.Equals("NOTIF-PSDD-MAIS-AUTOS"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("GERCAP01-NOVO") || y.Modelo.Equals("GERCAP01-NOVO"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("GERCAP11-NOVO") || y.Modelo.Equals("GERCAP11-NOVO"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("GERCAP08-NOVO") || y.Modelo.Equals("GERCAP08-NOVO"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("GERCAP02-NOVO") || y.Modelo.Equals("GERCAP02-NOVO"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("GERCAP02-NOVO-1AUTO") || y.Modelo.Equals("GERCAP02-NOVO-1AUTO"))
                //{
                //    return 1;
                //}
                //if (x.Modelo.Equals("GERCAP04-NOVO") || y.Modelo.Equals("GERCAP04-NOVO"))
                //{
                //    return 1;
                //}
 * 
 * 
 * 
 * 
 * 
 *  if (x.Height.CompareTo(y.Height) != 0)
        {
            return x.Height.CompareTo(y.Height);
        }
        else if (x.Length.CompareTo(y.Length) != 0)
        {
            return x.Length.CompareTo(y.Length);
        }
        else if (x.Width.CompareTo(y.Width) != 0)
        {
            return x.Width.CompareTo(y.Width);
        }
        else
        {
            return 0;
        }
 private class SortYearAscendingHelper: IComparer
      {
         int IComparer.Compare(object a, object b)
         {
            Car c1=(Car)a;
            Car c2=(Car)b;

            if (c1.year > c2.year)
               return 1;

            if (c1.year < c2.year)
               return -1;

            else
               return 0;
         }
 */