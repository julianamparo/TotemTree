using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TotemTree.BLL;
using TotemTree.Entities;


namespace TotemTree
{
    public partial class MindMap : System.Web.UI.Page
    {
        TemaBO temaBO = new TemaBO();
        UsuarioBO usuarioBO = new UsuarioBO();
        ArrayList cores = new ArrayList();
        List<int> jafoi = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {

           

            cores.Add(Color.Yellow);
            cores.Add(Color.Red);
            cores.Add(Color.Blue);
            cores.Add(Color.Green);
            cores.Add(Color.Black);
            cores.Add(Color.Orange);
            cores.Add(Color.Purple);
            cores.Add(Color.Navy);

            cores.Add(System.Drawing.Color.Pink);

            cores.Add(System.Drawing.Color.Gold);

            RadDiagram RadDiagram1 = new RadDiagram();
            int idTema = Convert.ToInt32(Request.QueryString["Tema"]);
            Tema temaPrincipal = temaBO.buscarTema(idTema);
            ArrayList temas = temaBO.buscarFilhosdeTema(idTema);          

            // General diagram settings
            RadDiagram1.Width = 800;
            RadDiagram1.Height = 600;
            RadDiagram1.ShapeDefaultsSettings.Width = 140;
            RadDiagram1.ShapeDefaultsSettings.Height = 30;
            RadDiagram1.ShapeDefaultsSettings.StrokeSettings.Color = "#fff";
            RadDiagram1.ShapeDefaultsSettings.ContentSettings.FontSize = 12;
            Form.Controls.Add(RadDiagram1);

            // Layout settings
            RadDiagram1.LayoutSettings.Enabled = true;
            RadDiagram1.LayoutSettings.Type = Telerik.Web.UI.Diagram.LayoutType.Layered;
            RadDiagram1.LayoutSettings.Subtype = Telerik.Web.UI.Diagram.LayoutSubtype.Right;
            RadDiagram1.LayoutSettings.VerticalSeparation = 20;
            RadDiagram1.LayoutSettings.HorizontalSeparation = 30;

            AddDiagramShape(temaPrincipal.idTema.ToString(), "#8CB20F", temaPrincipal.titulo, "#fff", RadDiagram1);

            criarMapa(temas, RadDiagram1);


        }


        void criarMapa(ArrayList temas, RadDiagram diagram)
        {
            Color cor = new Color();
            if (temas.Count > 0)
            {
                int corEscolhida = escolherCor();
                jafoi.Add(corEscolhida);
                cor = (Color)cores[corEscolhida];
            }

            foreach (Tema tema in temas)
            {
                ConnectDiagramShapes(tema.idTemaPai.ToString(), tema.idTema.ToString(), diagram);
                AddDiagramShape(tema.idTema.ToString(), cor.Name.ToString(), tema.titulo, "#fff", diagram);
                ArrayList filhosTema = temaBO.buscarFilhosdeTema(tema.idTema);
                criarMapa(filhosTema, diagram);
            }

            
            
        }

        int escolherCor()
        {
            bool ok = true;
            int n = 1;
            while (ok)
            {
                
                if (jafoi.Contains(n))
                    n = n + 1;
                else
                {
                    return n;
                }
            }

            return 1;
          
        }
        protected void AddDiagramShape(string shapeID, string backgroundColor, string contentText, string contentColor, RadDiagram diagram)
        {
            var shape = new DiagramShape()
            {
                Id = shapeID,
            };
            shape.ContentSettings.Text = contentText;
            shape.ContentSettings.Color = contentColor;
            shape.FillSettings.Color = backgroundColor;
            diagram.ShapesCollection.Add(shape);
        }

        protected void ConnectDiagramShapes(string startShapeID, string endShapeID, RadDiagram diagram)
        {
            var connection = new DiagramConnection();
            connection.FromSettings.ShapeId = startShapeID;
            connection.ToSettings.ShapeId = endShapeID;
            diagram.ConnectionsCollection.Add(connection);
        }

    }

    
    
}