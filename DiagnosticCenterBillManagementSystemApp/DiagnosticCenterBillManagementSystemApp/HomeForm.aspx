<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.HomeForm" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Diagnostic Center Management</title>
    <!-- Stylesheets -->
    <link rel="shortcut icon" type="image/png" href="images/favicon.png" />
    <link href="CSS/bootstrap.css" rel="stylesheet">
    <link href="CSS/style.css" rel="stylesheet">    
    <!-- Responsive -->
    <link href="CSS/responsive.css" rel="stylesheet"> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">


</head>
<body class="theme-green">
<div class="page-wrapper">
    <!-- Preloader -->
    <div class="preloader"></div>
    <!-- Main Header / Style One-->
				
    <header class="main-header header-style-one"> 
        <!-- Header Top -->
        <div class="header-top">
            <div class="container clearfix ptn pbn"> 
                <!--Top Left-->
                <div class="top-left pull-left">
                    <ul class="info-nav clearfix">
                        <li> 
                            <!--Social Links-->
                            <div class="social-links pull-left"> <span class="text-theme-color">Follow Us</span> : <a href="#"><span class="fa fa-facebook-f"></span></a> <a href="#"><span class="fa fa-twitter"></span></a> <a href="#"><span class="fa fa-google-plus"></span></a> <a href="#"><span class="fa fa-linkedin"></span></a> </div>
                        </li>
                        <li><a href="mailto:yourmail@gmail.com"><span class="icon icon-Mail mr10"></span>Opening Hours</a></li>
                    </ul>
                </div>
                <!--Top Right-->
                <div class="top-right pull-right clearfix"> 
                    <!--Lang Bar-->
                    <ul class="info-nav clearfix">
                        <li><a href="#"><i class="icon icon-Phone mr10 text-theme-color"></i><span class="ml5">Emergency Line</span> (+123) 2456 987</a></li>
                        <li><a href="#" class="text-uppercase appoinment"><i class="icon icon-Pen mr10 text-theme-color "></i> Make an appoinment</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- Header Top End --> 
				  
        <!--Header-Main Box-->
        <div class="header-mainbox">
            <div class="container ptn pbn">
                <div class="clearfix">
                    <div class="pull-left">
                        <div class="logo"> <a href="index-mp-layout1.html"><img src="images/logo.png" alt="" title="Green"></a> </div>
                    </div>
                    <div class="outer-box clearfix"> 
                        <!-- Main Menu -->
                        <nav class="main-menu logo-outer">
                            <div class="navbar-header"> 
                                <!-- Toggle Button -->
                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse"> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
                            </div>
                            <div class="navbar-collapse collapse clearfix">
                                <ul class="navigation clearfix">
                                    <li class=""> <a href="HomeForm.aspx">Home</a>
							                  	
                                    </li>
							                
                                    <li class="dropdown"> <a href="#">Setup</a>
                                        <ul>
                                            <li><a href="TestTypeSetupForm.aspx">Test Type</a></li>
                                            <li><a href="TestNameSetupForm.aspx">Test</a></li>
                                        </ul>
                                    </li>
                                    <li class="dropdown"><a href="#">Test Request</a>
                                        <ul>
                                            <li><a href="TestRequestEntryForm1.aspx">Entry</a></li>
                                            <li><a href="PaymentForm.aspx">Payment</a></li>
                                        </ul>
                                    </li>
                                    <li class="dropdown"> <a href="#">Report</a>
                                        <ul>
                                            <li><a href="TestWiseReportForm.aspx">Test Wise Report</a></li>
                                            <li><a href="TypeWiseReportForm.aspx">Type Wise Report</a></li>
                                            <li><a href="UnpaidBillReportForm.aspx">Unpaid Bill Report</a></li>
                                        </ul>
                                    </li>
                                    <li class=""> <a href="PdfGenerator.aspx">Blog</a>
							                  	
                                    </li>
                                    <li class=""> <a href="#">About us</a>
							                  	
                                    </li>
                                    <li class=""> <a href="#">Contact Us</a>
							                  	
                                    </li>
                                </ul>
                            </div>
                        </nav>
                        <!-- Main Menu End--> 
                    </div>
                </div>
            </div>
        </div>
        <!--Header Main Box End--> 
    </header>
    
    
        <section class="gallery-one overlayer default-overlay parallax" data-bg-image="images/bg/bg1.jpg">
            <div class="container pbn">
                <div class="section-title">
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2 text-center">
                            <h6>WE CARE ABOUT PATIENT</h6>
                            <h2 class="text-white">OUR OUTSTANDING<span> SERVICES</span></h2>
                            <p class="text-white">Sed malesuada nunc sit amet quam hendrerit, mollis vulputate risus tristique. Quisque dapibus eros et dolor accumsan, sit amet interdum tortor imperdiet.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div width="200px;">
                        
            &nbsp
        </div>
  
    <!-- Section: Our Departments -->
    <section class="our-department">
        <div class="container ptn">
            <div class="section-title">
                <div class="row">
                    <div class="col-md-4">
                        <h6>Latest work</h6>
                        <h2>Our <span> Departments</span></h2>
                    </div>
                    <div class="col-md-7">
                        <p>Sed malesuada nunc sit amet quam hendrerit, mollis vulputate risus tristique. Quisque dapibus eros et dolor accumsan, sit amet interdum tortor imperdiet.</p>
                    </div>
                </div>
            </div>
            <div class="section-wrap">
                <div class="row">
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/1.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-stomach-1"></i>
                            <div class="service-box-content">
                                <h5><a href="TestTypeSetupForm.aspx">TEST TYPE SETUP</a></h5>
                                <a href="TestTypeSetupForm.aspx">Click Here</a>
                            </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/2.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-heart"></i>
                            <div class="service-box-content">
                                <h5><a href="TestNameSetupForm.aspx">TEST NAME SETUP </a></h5>
                                <a href="TestNameSetupForm.aspx">Click Here</a>
                             </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/3.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-lungs"></i>
                            <div class="service-box-content">
                                <h5><a href="TestRequestEntryForm1.aspx">ENTRY</a></h5>
                                <a href="#">TestRequestEntryForm1.aspx</a>
                            </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/4.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-liver"></i>
                            <div class="service-box-content">
                                <h5><a href="PaymentForm.aspx">PAYMENT </a></h5>
                                <a href="#">PaymentForm.aspx</a>
                            </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/5.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-uterus"></i>
                            <div class="service-box-content">
                                <h5><a href="TestWiseReportForm.aspx">TEST WISE REPORT </a></h5>
                                <a href="#">TestWiseReportForm.aspx</a>
                            </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/6.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-teeth-10"></i>
                            <div class="service-box-content">
                                <h5><a href="TypeWiseReportForm.aspx">TYPE WISE REPORT</a></h5>
                                <a href="#">TypeWiseReportForm.aspx</a>
                            </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="service-box style-1" style="background-image:url(images/service/7.jpg);">
                            <div class="service-box-overlay"></div>
                            <i class="flaticon-skeleton"></i>
                            <div class="service-box-content">
                                <h5><a href="UnpaidBillReportForm.aspx">UNPAID BILL REPORT </a></h5>
                                <a href="#">UnpaidBillReportForm.aspx</a>
                            </div>
                            <!-- service-box-content --> 
                        </div>
                    </div>
                                
                </div>
            </div>
        </div>
    </section>
</div>
<!--End Main Header --> 
    <div class="scroll-to-top scroll-to-target" data-target=".main-header"><span class="fa fa-long-arrow-up"></span></div>
    <script src="js/jquery.js"></script> 
    <script src="js/all-jquery.js"></script> 
    <script src="js/script.js"></script>
</body>
</html>
