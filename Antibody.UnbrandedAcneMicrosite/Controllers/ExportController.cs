using BitMiracle.Docotic.Pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Antibody.UnbrandedAcneMicrosite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public ExportController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Index(formViewModel formviewmodel)
        {
            string bit_key = Configuration.GetValue<string>("BitMiracle_key");
            string bit_name = Configuration.GetValue<string>("BitMiracle_name");
            string azure_key = Configuration.GetValue<string>("Azure_storage_key");
            string container_name = Configuration.GetValue<string>("container_name");

            BitMiracle.Docotic.LicenseManager.AddLicenseData(bit_key, bit_name);


            string filename = Guid.NewGuid() + ".pdf";
            string localpath = "";
            string localFilePath = Path.Combine(localpath, filename);

            try
            {
                string templatePath = Environment.CurrentDirectory + @"\wwwroot\";
                string formVersion = formviewmodel.language == "en" ? "fillable_personal_guide_en.pdf" : "fillable_personal_guide_fr.pdf";
                string templateFile = Path.Combine(templatePath + formVersion);
                using (PdfDocument pdf = new PdfDocument(templateFile))
                {
                    foreach (PdfControl control in pdf.GetControls())
                    {
                        switch (control.Name)
                        {
                            case "ck_1_1":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_1_1;
                                break;
                            case "ck_1_2":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_1_2;
                                break;
                            case "ck_1_3":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_1_3;
                                break;
                            case "ck_1_4":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_1_4;
                                break;
                            case "ck_2_1":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_1;
                                break;
                            case "ck_2_2":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_2;
                                break;
                            case "ck_2_3":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_3;
                                break;
                            case "ck_2_4":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_4;
                                break;
                            case "ck_2_5":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_5;
                                break;
                            case "ck_2_6":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_6;
                                break;
                            case "ck_2_7":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_2_7;
                                break;
                            case "ck_3_1":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_3_1;
                                break;
                            case "ck_3_2":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_3_2;
                                break;
                            case "ck_3_3":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_3_3;
                                break;
                            case "ck_3_4":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_3_4;
                                break;
                            case "ck_4_1":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_1;
                                break;
                            case "ck_4_2":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_2;
                                break;
                            case "ck_4_3":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_3;
                                break;
                            case "ck_4_4":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_4;
                                break;
                            case "ck_4_5":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_5;
                                break;
                            case "ck_4_6":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_6;
                                break;
                            case "ck_4_7":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_7;
                                break;
                            case "ck_4_8":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_8;
                                break;
                            case "ck_4_9":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_9;
                                break;
                            case "ck_4_10":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_10;
                                break;
                            case "ck_4_11":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_4_11;
                                break;
                            case "ck_5_1":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_5_1;
                                break;
                            case "ck_5_2":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_5_2;
                                break;
                            case "ck_5_3":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_5_3;
                                break;
                            case "ck_5_4":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_5_4;
                                break;
                            case "ck_5_5":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_5_5;
                                break;
                            case "ck_6_1":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_6_1;
                                break;
                            case "ck_6_2":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_6_2;
                                break;
                            case "ck_6_3":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_6_3;
                                break;
                            case "ck_6_4":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_6_4;
                                break;
                            case "ck_6_5":
                                ((PdfCheckBox)control).Checked = formviewmodel.ck_6_5;
                                break;
                            case "txt_2_1":
                                ((PdfTextBox)control).Text = formviewmodel.txt_2_1;
                                break;
                            case "txt_4_1":
                                ((PdfTextBox)control).Text = formviewmodel.txt_4_1;
                                break;
                            case "txt_5_1":
                                ((PdfTextBox)control).Text = formviewmodel.txt_5_1;
                                break;
                            case "txt_6_1":
                                ((PdfTextBox)control).Text = formviewmodel.txt_6_1;
                                break;

                        }
                    }
                    pdf.Save(localFilePath);
                    //string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
                    string connectionString = azure_key;
                    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                    //var azureAccount = CloudStorageAccount.Parse(azure_key);
                   //CloudBlobClient cloudblobclient = azureAccount.CreateCloudBlobClient();


                    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(container_name);
                    BlobClient blobClient = containerClient.GetBlobClient(filename);
                    await blobClient.UploadAsync(localFilePath, true).ContinueWith((t) =>
                    {
                        System.IO.File.Delete(filename);
                    });
                }
            }
            catch (Exception e)
            {

                throw;
            }

            //Process.Start(pathToFile);

            var result = new OkObjectResult(new { message = "200 OK", filename = filename });
            return result;
        }

        public class formViewModel
        {
            public string language { get; set; }
            public bool ck_1_1 { get; set; }
            public bool ck_1_2 { get; set; }
            public bool ck_1_3 { get; set; }
            public bool ck_1_4 { get; set; }
            public bool ck_2_1 { get; set; }
            public bool ck_2_2 { get; set; }
            public bool ck_2_3 { get; set; }
            public bool ck_2_4 { get; set; }
            public bool ck_2_5 { get; set; }
            public bool ck_2_6 { get; set; }
            public bool ck_2_7 { get; set; }
            public bool ck_3_1 { get; set; }
            public bool ck_3_2 { get; set; }
            public bool ck_3_3 { get; set; }
            public bool ck_3_4 { get; set; }
            public bool ck_4_1 { get; set; }
            public bool ck_4_2 { get; set; }
            public bool ck_4_3 { get; set; }
            public bool ck_4_4 { get; set; }
            public bool ck_4_5 { get; set; }
            public bool ck_4_6 { get; set; }
            public bool ck_4_7 { get; set; }
            public bool ck_4_8 { get; set; }
            public bool ck_4_9 { get; set; }
            public bool ck_4_10 { get; set; }
            public bool ck_4_11 { get; set; }
            public bool ck_5_1 { get; set; }
            public bool ck_5_2 { get; set; }
            public bool ck_5_3 { get; set; }
            public bool ck_5_4 { get; set; }
            public bool ck_5_5 { get; set; }
            public bool ck_6_1 { get; set; }
            public bool ck_6_2 { get; set; }
            public bool ck_6_3 { get; set; }
            public bool ck_6_4 { get; set; }
            public bool ck_6_5 { get; set; }
            public string txt_2_1 { get; set; }
            public string txt_4_1 { get; set; }
            public string txt_5_1 { get; set; }
            public string txt_6_1 { get; set; }
        }
    }
}
