using DITest.Data.Repositories;
using DITest.Service;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private IProductCategoryService productCategoryService;
        private readonly IFormFactory formFactory;
        private readonly IProductCategoryRepository productCategoryRepository;
        public Form1(IProductCategoryService productCategoryService,IProductCategoryRepository productCategoryRepository, IFormFactory formFactory)
        {
           
           
            if (formFactory == null)
            {
                throw new ArgumentNullException("formFactory");
            }
            this.productCategoryService = productCategoryService;
            this.formFactory = formFactory;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadProductCategory();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }
        private void LoadProductCategory()
        {
            var data = productCategoryService.GetAll();
            gridControl1.DataSource = data;
        }
    }
}