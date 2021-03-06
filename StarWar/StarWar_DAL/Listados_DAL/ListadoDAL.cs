﻿using StarWar_DAL.Conexion;
using StarWar_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar_DAL.Listados_DAL
{
   public class ListadoDAL
    {

        MiConexion miConexion = new MiConexion();
        SqlConnection conexion = new SqlConnection();
        SqlCommand miComando = new SqlCommand();
        SqlDataReader miLector;

        /// <summary>
        /// Este metodo me permite obtener un listado de las trilagias 
        /// </summary>
        /// <returns></returns>
        public List<Trilogia> obtenerTrilogiaDAL()
        {
            Trilogia trilogia;
            List<Trilogia> listaTrilogias = new List<Trilogia>();        

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select idTrilogia,nombreTrilogia from trilogias";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                while (miLector.Read())
                {
                    trilogia = new Trilogia();
                    trilogia.IdTrilogia = (Int32)miLector["idTrilogia"];
                    trilogia.NombreTrilogia = (String)miLector["nombreTrilogia"];

                    listaTrilogias.Add(trilogia);
                }   
              //  miComando.Parameters.Clear();
            }
            catch (SqlException sql) { throw sql; }

            return (listaTrilogias);
        }

    }
}
