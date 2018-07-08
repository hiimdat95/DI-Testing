using Autofac;
using DITest.Data.Infrastructure;
using DITest.Data.Repositories;
using DITest.Service;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public IProductCategoryService _productCategoryService;
        public ICommonService _commonService;
        //public IUnitOfWork unitOfWork; IUnitOfWork
        public Form1(IProductCategoryService productCategoryService, ICommonService commonService)
        {
            this._productCategoryService = productCategoryService;
            this._commonService = commonService;
            //this.unitOfWork = unitOfWork;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadProductCategory();
        }
       
        private void LoadProductCategory()
        {
            var data = _commonService.GetListSystemConfig();
            gridControl1.DataSource = data;
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
    }
}