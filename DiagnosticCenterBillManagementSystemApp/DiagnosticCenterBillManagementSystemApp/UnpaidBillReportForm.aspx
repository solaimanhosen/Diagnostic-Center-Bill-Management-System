﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReportForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.UnpaidBillReportForm" %>

<!DOCTYPE html>

<html>
<head runat="server">
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

    <link href="CSS/reset.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous"/>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    
    <script src="Scripts/jquery-3.2.1.js"></script>
    <script src="Scripts/jquery.validate.js"></script>
    <script>
        
	
       

        $().ready(function() {
            // validate the comment form when it is submitted
            // $("#form1").validate();
            // validate signup form on keyup and submit
            $("#form1").validate({
                rules: {
                    fromDateTextBox: {
                        required: true
                    },
                    toDateTextBox: {
                        required: true

                    }
                }

            });
        });


    </script> 
    
    <style>
        #success_message{ display: none;}
        body {
            background-color: #bdc3c7;
        }

        .table-fixed {
            width: 85%;
            background-color: #f3f3f3;
            margin-left: 140px;
        }
        .table-fixed tbody {
            height: 200px;
            overflow-y: scroll;
            width: 85%;
        }
        .table-fixed thead {
            width: 85%;
        }
        .table-fixed thead, .table-fixed tbody, .table-fixed tr, .table-fixed td, .table-fixed th {
            display: block;
        }
        .table-fixed tbody td {
            float: left;
        }
        .table-fixed thead tr th {
            float: left;
            background-color: #f39c12;
            border-color: #e67e22;
        }
    </style>
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
                                    <li class=""> <a href="#">Blog</a>
							                  	
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
    <div class="container">
        <form id="form1" runat="server" class ="well form-horizontal"  method="post" >
            <fieldset>
                <!-- Form Name -->
                <legend><center><h2><b>UNPAID BILL REPORT</b></h2></center></legend><br>

                <!-- Text input-->

                <div class="form-group">
                    <label class="col-md-4 control-label">FROM DATE</label>  
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                            <input runat="server"  name="fromDateTextBox" id="fromDateTextBox"  class = "form-control" type="date" />
                        </div>
                    </div>
                </div>
            
                <div class="form-group">
                    <label class="col-md-4 control-label">TO DATE</label>  
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                            <input runat="server"  name="toDateTextBox" id="toDateTextBox"  class = "form-control" type="date" />
                        </div>
                    </div>
                </div>
            
           
                
                <div class="form-group">
                    <label class="col-md-4 control-label"></label>
                    <div class="col-md-4" style="margin-left: 58%;"><br>
                        <asp:Button type="submit" class="btn btn-warning"  runat="server" ID="showButton" Text="SHOW" OnClick="showButton_Click"  />
                    </div>
                </div>
                
                
                        
                <div class="form-group">
                    <table ID="myTable"  class="table table-fixed" style="width: 100%;margin-left: 14%; ">
                        <thead >
                        <tr>
                            <th  class="col-xs-2">SL</th>
                            <th  class="col-xs-2">BILL NO</th>
                            <th class="col-xs-2">CONTACT NO</th>
                            <th class="col-xs-2">PATIENT NAME</th>   
                            <th class="col-xs-2">BILL AMOUNT</th>    
                        </tr>
                        </thead>
                    </table>
                    <div class="table-responsive" div style="overflow: scroll; height: 200px;"> 
                        <asp:GridView ID="unpaidBillGridView" showHeader="False" class="col-md-4 inputGroupContainer" runat="server" style="margin-left: 15%; margin-right: 15%;" Width="70%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"  EmptyDataText="There are no data records to display.">  
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("SL")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Bill Number")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Contact No")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Patient Name")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Bill Amount")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                            </Columns>
                        </asp:GridView>  
                    </div>
                </div>
            
                <div class="form-group">
                    <asp:Button type="submit" class="btn btn-warning"  runat="server" ID="pdfButton" Text="PDF" OnClick="pdfButton_Click"  />
                    <label class="col-md-4 control-label">TOTAL AMOUNT</label>  
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                            <input runat="server"  name="totalamount" id="totalamount"  class = "form-control" type="Text" disabled />
                        </div>
                    </div>
                </div>
            

                <!-- Success message -->
                <div class="alert alert-success" role="alert" id="success_message">Success <i class="glyphicon glyphicon-thumbs-up"></i> Success!.</div>
            

            </fieldset> 
        </form>
    </div>
</div>
<!--End Main Header --> 
<script src="js/jquery.js"></script> 
<script src="js/all-jquery.js"></script> 
<script src="js/script.js"></script>
</body>
</html>
