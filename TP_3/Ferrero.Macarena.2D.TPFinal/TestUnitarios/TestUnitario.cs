using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiDomo;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitario
    {
        /// <summary>
        /// Test unitario que valida que los constructores creen correctamente el objeto
        /// </summary>
        [TestMethod]
        public void Test01_Validar_Que_Se_Construyan_Los_Objetos()
        {
            //Arrange
            KitMadera kitMadera = new KitMadera(2, EFrecuencia.F1, "Federico", ETipoConexion.GoodKarma, "Madera", EEstado.Pendiente);
            KitPVC kitPVC = new KitPVC(3, EFrecuencia.F2, "Lautaro", ETipoConexion.Incrustable, "PVC", EEstado.Pendiente);
            //Act
            //Assert
            Assert.IsNotNull(kitMadera);
            Assert.IsNotNull(kitPVC);

        }

        /// <summary>
        /// Test Unitario que valida que se lanze una excepcion si el Radio esta fuera del rango que se permite construir
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DomoException))]
        public void Test02_Lanzar_Excepcion_Si_Se_Quiere_Asignar_Valor_Del_Radio_Fuera_Del_Rango()
        {
            //Arange
            KitMadera kitMadera = new KitMadera(6, EFrecuencia.F1, "Federico", ETipoConexion.GoodKarma, "Madera", EEstado.Pendiente);
            KitMadera kitMadera2 = new KitMadera(1, EFrecuencia.F1, "Federico", ETipoConexion.GoodKarma, "Madera", EEstado.Pendiente);

            //Act
            //Assert
        }

        /// <summary>
        /// Test Unitario que valide que se imprima correctamente la informacion del objeto
        /// </summary>
        [TestMethod]
        public void Test03_Imprimir_Informacion_Del_Objeto()
        {
            //Arrange
            KitPVC kitPVC = new KitPVC(2, EFrecuencia.F1, "Esteban", ETipoConexion.Incrustable, "PVC", EEstado.Pendiente);
            //Act
            string texto = null;
            texto = kitPVC.InformeFabricacion();
            //Assert
            Assert.IsNotNull(texto);
            Assert.AreNotEqual(0,texto.Length);
        }


        /// <summary>
        /// Test Unitario que valida que se lanze una Excepcion si el nombre a asignar es muy corto
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DomoException))]
        public void Test04_Lanzar_Excepcion_Si_Se_Quiere_Asignar_Nombre_Menor_A_3_Letras()
        {
            //Arrange
            KitPVC kitPVC = new KitPVC(2, EFrecuencia.F2, "E", ETipoConexion.Incrustable, "PVC", EEstado.Pendiente);
            KitMadera kitMadera = new KitMadera(2, EFrecuencia.F1, "e", ETipoConexion.Cono, "Madera", EEstado.Pendiente);
            //Act
            //Assert
        }


        [TestMethod]
        public void Test05_Guardar_Domo_En_Base_Datos()
        {
            //Arrange
            DomoDAO domo = new DomoDAO();
            KitPVC kitPVC = new KitPVC(2, EFrecuencia.F2, "Esteban", ETipoConexion.Incrustable, "PVC", EEstado.Pendiente);
            //Act
            domo.Guardar(kitPVC);
            //Assert
        }


    }
}
