using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ПР5_автокад_
{
	public class CommandHandler
	{
		private readonly Database database;
		private readonly Editor editor;
		public int i;
		public CommandHandler()
		{
			var activeDocument = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
			database = activeDocument.Database;
			editor = activeDocument.Editor;
		}

		private void CreateLayer(string name)
		{
			using (var transaction = database.TransactionManager.StartTransaction())
			{
				var layertable = (LayerTable)transaction.GetObject(database.LayerTableId, OpenMode.ForRead);

				var layerRecord = new LayerTableRecord
				{
					Name = name
				};

				layertable.UpgradeOpen();
				var layerTableId = layertable.Add(layerRecord);
				transaction.AddNewlyCreatedDBObject(layerRecord, true);

				database.Clayer = layerTableId;

				transaction.Commit();

				editor.WriteMessage($"Шар з именем {name} создан успешно.");
			}
		}
		[CommandMethod("ViktorCircle")]
		public void ViktorCircle()
		{

			CreateLayer($"Circle_{i}");
			var form = new VCircle();
			if (form.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			var center = form.Center;
			var radius = form.Radius;

			form.Dispose();

			using (var transaction = database.TransactionManager.StartTransaction())
			{
				var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);
				var record = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				using (var circle = new Circle())
				{
					circle.Center = center;
					circle.Radius = radius;
					record.AppendEntity(circle);
					transaction.AddNewlyCreatedDBObject(circle, true);
				}
				transaction.Commit();
				editor.WriteMessage($"\nКруг с центром в точке [{center.X} {center.Y} 0] и радиусом {radius} создан успешно.");
			}
			i++;
		}
		[CommandMethod("ViktorPoint")]
		public void ViktorPoint()
		{
			
			CreateLayer($"Point_{i}");
			var form = new VPoint();
			if (form.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			var tochka = form.Tochka;

			form.Dispose();

			using (var transaction = database.TransactionManager.StartTransaction())
			{
				var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);
				var record = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

				using (Line d = new Line(tochka,tochka))
				{
					record.AppendEntity(d);
					transaction.AddNewlyCreatedDBObject(d, true);
					transaction.Commit();
				}
				editor.WriteMessage($"\n Точка с координатами  [{tochka.X} {tochka.Y} {tochka.Z}] создана успешно.");

			}
			i++;
		}
		[CommandMethod("ViktorLine")]
		public void ViktorLine()
		{

			CreateLayer($"Line_{i}");
			var form = new VLine();
			if (form.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			var point1 = form.Point1;
			var point2 = form.Point2;

			form.Dispose();

			using (var transaction = database.TransactionManager.StartTransaction())
			{
				var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);
				var record = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				using (Line acLine = new Line(point1, point2))
				{
					record.AppendEntity(acLine);
					transaction.AddNewlyCreatedDBObject(acLine, true);
				}
				transaction.Commit();
				editor.WriteMessage("\n Линия создана успешно.");
			}
			i++;
		}
		[CommandMethod("ViktorPolyLine")]
		public void ViktorPolyLine()
		{

			CreateLayer($"PolyLine_{i}");
			var form = new Vpolyline();
			if (form.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			var point1 = form.Point1;
			var point2 = form.Point2;
			var point3 = form.Point3;

			form.Dispose();

			using (var transaction = database.TransactionManager.StartTransaction())
			{
				var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);
				var record = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				using (Polyline acPolyline = new Polyline())
				{
					acPolyline.AddVertexAt(0, point1, 0, 0, 0);
					acPolyline.AddVertexAt(1, point2, 0, 0, 0);
					acPolyline.AddVertexAt(2, point3, 0, 0, 0);
					record.AppendEntity(acPolyline);
					transaction.AddNewlyCreatedDBObject(acPolyline, true);
				}
				transaction.Commit();
				editor.WriteMessage("\n Полиния создана успешно.");
			}
			i++;
		}
		[CommandMethod("ViktorElipse")]
		public void ViktorElipse()
		{

			CreateLayer($"Elipse_{i}");
			var form = new VElipse();
			if (form.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			Point3d center = form.center;
			Vector3d normal = Vector3d.ZAxis;
			Vector3d majorAxis = form.MV*10 * Vector3d.XAxis + form.MV*10 * Vector3d.YAxis;
			double radius = form.Radius/100;
			double startAng = 0.0;
			double endAng = Math.PI * 2;
			using (var transaction = database.TransactionManager.StartTransaction())
			{
				var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);
				var record = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				using (Ellipse acEllipse = new Ellipse(center, normal, majorAxis, radius, startAng, endAng))
				{
					record.AppendEntity(acEllipse);
					transaction.AddNewlyCreatedDBObject(acEllipse, true);
				}
				transaction.Commit();
				editor.WriteMessage("\n Элипс создан успешно.");
			}
			i++;
		}
		[CommandMethod("ViktorSquare")]
		public void ViktorSquare()
		{

			CreateLayer($"Square_{i}");
			var form = new VSquare();
			if (form.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			Point2d point1 = form.Point1;
			Point2d point2 = form.Point2;
			Point2d point3 = form.Point3;
			Point2d point4 = form.Point4;
			using (var transaction = database.TransactionManager.StartTransaction())
			{
				ObjectIdCollection acObjIdColl = new ObjectIdCollection();
				Hatch acHatch = new Hatch();
				var blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, OpenMode.ForRead);
				var record = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
				using (Polyline square = new Polyline())
				{
					
					square.AddVertexAt(0, point1, 0, 0, 0);
					square.AddVertexAt(1, point2, 0, 0, 0);
					square.AddVertexAt(2, point3, 0, 0, 0);
					square.AddVertexAt(3, point4, 0, 0, 0);
					square.AddVertexAt(4, point1, 0, 0, 0);
					record.AppendEntity(square);
					transaction.AddNewlyCreatedDBObject(square, true);
					acObjIdColl.Add(square.ObjectId);
					record.AppendEntity(acHatch);
					transaction.AddNewlyCreatedDBObject(acHatch, true);
					acHatch.SetDatabaseDefaults();
					acHatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");
					acHatch.Color = Autodesk.AutoCAD.Colors.Color.FromRgb(255, 255, 255);
					acHatch.Associative = true;
					acHatch.AppendLoop(HatchLoopTypes.Outermost, acObjIdColl);
					acHatch.EvaluateHatch(true);
				}
				transaction.Commit();
				editor.WriteMessage("\n Квадрат создан успешно.");
			}
			i++;
		}

	}
}
