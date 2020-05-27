using System;
using System.Linq;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCoreQueriesEspaciales {
  class Program {
    static void Main (string[] args) {

      var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory (srid: 4326);			
      var miUbicacion = geometryFactory.CreatePoint (new Coordinate (-0.063952, 51.520940));

      using (var context = new ApplicationDbContext ()) {
        var resturantes = context.Restaurantes
				.OrderBy(r => r.Ubicacion.Distance(miUbicacion) )
				.Where(r => r.Ubicacion.IsWithinDistance(miUbicacion, 2000))
				.Select(r => new {r.Nombre, r.Ciudad, Distancia = r.Ubicacion.Distance(miUbicacion) } )
				.ToList();

    Console.WriteLine("-----------------------------------------------------------");

     foreach (var restaurante in resturantes )
		 {
				 System.Console.WriteLine($"{restaurante.Nombre} de {restaurante.Ciudad} ({restaurante.Distancia.ToString("N0")} metros de distancia )");
		 }

      }

    }
  }
}