using System.Linq;
using System.Windows.Forms;
using PrimaGeo.Backend;

namespace PrimaGeo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            geoDBCitiesBindingSource.DataSource = new GeoDB().CitiesContext.Cities.ToList();
        }
    }
}
