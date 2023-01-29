<%@ Page Language="VB" AutoEventWireup="false"    CodeFile="Inscripcion.aspx.vb" Inherits="Inscripcion" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Inscripción ITQ</title>
 <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <!-- Custom styles for this template -->
    <link href="../css/carousel.css" rel="stylesheet">
    <script src="../js/jquery.min.js"></script>
 
     
  

   
        <style type="text/css">
            .auto-style1 {
                width: 100%;
                max-width: 1140px;
                min-width: 992px;
                font-weight: bold;
                margin-left: auto;
                margin-right: auto;
                padding-left: 15px;
                padding-right: 15px;
            }
            .auto-style2 {
                font-weight: normal;
            }
            .auto-style3 {
                font-family: "Segoe UI";
                color: #800000;
            }
            .auto-style5 {
                font-family: "Segoe UI";
                font-size: xx-large;
            }
        .auto-style17 {
            width: 100%;
            background-color: #B5D0FB;
        }
            .auto-style19 {
                margin-bottom: 1rem;
                text-align: justify;
            }
            .auto-style20 {
                width: 852px;
            }
            .auto-style21 {
                height: 73px;
            }
            .auto-style22 {
                width: 234px;
            }
            .auto-style23 {
                width: 413px;
                height: 116px;
            }
        </style>



  </head>
<body>
    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>

         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
         <asp:Button ID="btnUpload" Text="Upload" runat="server"  Style="display: none" />


      
        
                    


        <div class="row">

      <div class="col-sm-3" style="">
       
           
            </div>
            
                    
               

      <div class="col-sm-7" style="">
            
   <section>
    <div class="container">
        <div class="container">
            <h4>
    
                      
                &nbsp;&nbsp;
                <img alt="" class="auto-style23" src="../images/logoitqv1.jpg" />
            </h4>
            <h3><span style="color: rgb(0, 117, 180); font-family: Viga; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;" class="auto-style5">MATRICULA ESCUELA DE IDIOMAS</span></h3>
            <div class="auto-style1">
                Registre toda la información requerida<span class="auto-style2">&nbsp;&nbsp;
                <asp:Label ID="LabelErrorcab" runat="server" Visible="False"></asp:Label>
                </span></div>
            <hr></hr>
        </div>
        <div class="container">
            <asp:Label ID="Label74" runat="server" Text="Se recomienda utilizar  el navegador Google Chrome"></asp:Label>
            </section>


          <div class="form-group">
                    <label class="control-label" for="Nombre">Tipo de documento</label>
<asp:DropDownList ID="CboTipoDoc" class="form-control" runat="server" Width="400px"> <asp:ListItem Value="1">Cédula</asp:ListItem>
                                            <asp:ListItem Value="2">Pasaporte</asp:ListItem></asp:DropDownList>
                     <label class="control-label" for="Nombre">
                     Digite el No. Cédula / Pasaporte</label>
                     <asp:TextBox ID="txtcedula" runat="server" autofocus="" class="form-control" placeholder="Introduzca su cédula/pasaporte" required="" Width="400px"></asp:TextBox>
                     <asp:ImageButton ID="ImageButton1" runat="server" Height="44px" ImageUrl="~/images/consulta.png" Width="144px" />
                     <asp:Label ID="lblCodTipoIdent0" runat="server" CssClass="auto-style3"></asp:Label>
                </div>  



                 <div class="form-group">
                    <label class="control-label" for="Nombre">Periodo</label>
                     <br />
                     <asp:Label ID="lblperiodo" runat="server" Width="400px"></asp:Label>
                </div> 
                
                                 <div class="form-group">
                    <label class="control-label" for="Nombre">Carrera</label>
<asp:DropDownList ID="CboCarrera" class="form-control" runat="server" AutoPostBack="True" Width="400px"> 
                     </asp:DropDownList>
                </div>  
                
                

                 <div class="form-group">
                    <label class="control-label" for="Nombre">Jornada de la carrera </label>
<asp:DropDownList ID="cbojornada" class="form-control" runat="server" AutoPostBack="True" Width="400px"> 
                     </asp:DropDownList>
                </div>  
                
                 
 
                  
                <div class="form-group">
                    <label class="control-label" for="Nombre">Nombres</label>
<asp:TextBox ID="Txtnombres"  class="form-control" runat="server" placeholder="Introduzca su nombre" Width="400px"  ></asp:TextBox>
                </div>   
                
                 <div class="form-group">
                    <label class="control-label" for="Nombre">Primer Apellido </label>
&nbsp;<asp:TextBox ID="Txtapellidopat"  class="form-control" runat="server" placeholder="Introduzca su apellido paterno" Width="400px"  ></asp:TextBox>
                </div>  

                 <div class="form-group">
                    <label class="control-label" for="Nombre">Segundo Apellido</label>
<asp:TextBox ID="Txtapellidomat"  class="form-control" runat="server" placeholder="Introduzca su apellido materno" Width="400px"  ></asp:TextBox>
                </div>  

                
          <asp:Panel ID="Panel1" runat="server" Visible="False">
                
                <div class="form-group">
                    <label class="control-label" for="Nombre">Fecha de nacimiento</label>
<asp:TextBox ID="txtfechaNac"  class="form-control" runat="server" placeholder="Introduzca fecha de nacimiento" Width="400px"  ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtfechaNac_CalendarExtender" runat="server" TargetControlID="txtfechaNac" PopupButtonID="Image1" Format="dd/MM/yyyy"  TodaysDateFormat="d MMMM, yyyy" >
                                        </ajaxToolkit:CalendarExtender>
        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/aulavirtual/images/Calendar_scheduleHS.png" AlternateText="Click en el calendario" />&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Label ID="Label37" runat="server" Text="Día / Mes / Año" style="font-size: small"></asp:Label>
                </div>   
                
                 <div class="form-group">
                    <label class="control-label" for="Nombre">Correo Electrónico Institucional ITQ </label>
<asp:TextBox ID="txtemail"  class="form-control" runat="server" placeholder="Introduzca su email" Width="400px" ></asp:TextBox>
                </div>  

                 <div class="form-group">
                    <label class="control-label" for="Nombre">Dirección Domicilio</label>
<asp:TextBox ID="txtdirecdomi"  class="form-control" runat="server" placeholder="Introduzca su dirección" MaxLength="150" Width="400px" ></asp:TextBox>
                </div>  

                 <div class="form-group">
                    <label class="control-label" for="Nombre">Teléfono Domicilio </label> 
                       <br />
                     <label class="control-label" for="Nombre">
                     &nbsp;Número
                     </label>
                
<asp:TextBox ID="txttelef"   runat="server" placeholder="Introduzca su teléfono" ></asp:TextBox>
                     &nbsp;&nbsp;
                     <label class="control-label" for="Nombre">
                     Celular</label> &nbsp;<label class="control-label" for="Nombre">
                     <asp:TextBox ID="TxtCelular" runat="server" autofocus="" placeholder="Introduzca su celular"></asp:TextBox>
                     </label>
                     <br />
                     <asp:Label ID="Label40" runat="server" Text="Ya dispone de una cuenta en la plataforma Cambridge, como estudiante del  ITQ" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:DropDownList ID="CboPlataforma" runat="server" AutoPostBack="True">
                         <asp:ListItem Value="0">NO</asp:ListItem>
                         <asp:ListItem Value="1">SI</asp:ListItem>
                     </asp:DropDownList>
                     <br />
                     <asp:Label ID="Label73" runat="server" Text="Ingrese el correo con el que se encuentra registrado en la plataforma Cambridge:"></asp:Label>
                     <asp:TextBox ID="txtemailCambridge" runat="server" class="form-control" placeholder="Introduzca su email" Width="400px"></asp:TextBox>
                </div>  

               
                  <div class="auto-style19">
                      Me comprometo a cancelar el valor <strong>NO REEMBOLSABLE</strong>, correspondiente a la matrícula, con la siguiente Forma de pago: (Enviar el comprobante de pago al&nbsp;<strong>correo pagos@itq.edu.ec, INDICANDO EL NOMBRE DEL TITULAR DE LA CUENTA Y DEL ESTUDIANTE</strong><br />&nbsp;&nbsp;<asp:CheckBox ID="Chk1" runat="server" AutoPostBack="True" Checked="True" />
                      <asp:Label ID="Label38" runat="server" Text=" Un pago de $110 "></asp:Label>
                      <br />
                      &nbsp;<asp:CheckBox ID="Chk2" runat="server" AutoPostBack="True" />
                      <asp:Label ID="Label39" runat="server" Text=" Dos pagos de $55 "></asp:Label>
                      <br />
                          </div>  

          

                <div class="form-group">
                    <strong>Subir copia a color de la cédula, papeleta de votación y comprobante de pago</strong> (Documentos requeridos como confirmación de que ha participado en el proceso de matrícula de manera libre y voluntaria. Subirlos en 1 solo archivo) *
                    <br />
                    <asp:Label ID="Label71" runat="server" style="font-weight: 700" Text="Seleccione el archivo y subir"></asp:Label>
                </div>


          </asp:Panel>

                  <table class="auto-style17">
                    <tr>
                        <td class="auto-style21">
                            <asp:Label ID="lblMesg" runat="server" style="color: #990000; font-family: 'Segoe UI'; font-weight: 700" Text=""></asp:Label>
                        </td>
                        <td class="auto-style21">
                            

                            <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" CompleteBackColor="White" OnClientUploadComplete="uploadComplete" OnClientUploadError="uploadError" OnUploadedComplete="FileUploadComplete" ThrobberID="imgLoader" UploaderStyle="Modern" UploadingBackColor="#CCFFFF" Width="400px" />
               
                            <div class="panel panel-primary">
        <asp:Image ID="imgLoader" runat="server" ImageUrl = "~/images/control.gif" /> 
                         </div>

                               </td>
                        <div class="panel panel-primary">
         
                            <asp:Label ID="Label1" runat="server" Width="500px"></asp:Label></div>
                        <td class="auto-style21">
                            <asp:Label ID="lblcn" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="Label72" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblMessageced" runat="server" ForeColor="Green" style="color: #CC3300; font-weight: 700" Text="Archivo adjuntado" Visible="False" />
                            <asp:Label ID="lblarchivoadjunto" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
        


              
                <br />



               
                



                             <div class="form-group">                
                    
                    <div>
                        <asp:UpdatePanel ID="UpdatePCabecera" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                            <ContentTemplate>
                                &nbsp;<asp:Label ID="Label9" runat="server" style="font-size: large; font-weight: 700; font-family: Verdana; text-align: center;" Text="Matricula de Inglés" Width="513px"></asp:Label>
                                <br />
                                <table bgcolor="#CCCCCC" border="0" cellpadding="0" cellspacing="1" class="style8">
                                    <tr>
                                        <td class="style37">&nbsp;</td>
                                        <td class="auto-style22">&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td class="style37">
                                            <asp:Label ID="Label67" runat="server" Height="16px" style="text-align: right" Text="Asignatura:" Width="150px"></asp:Label>
                                        </td>
                                        <td class="auto-style22">
                                            <asp:DropDownList ID="CboAsignatura" runat="server" AutoPostBack="True" Font-Size="12pt" Height="25px" style="font-size: small; font-style: normal; font-weight: 700; font-family: Verdana;" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style40">
                                            <asp:Label ID="Label63" runat="server" Height="16px" style="text-align: right" Text="Modalidad" Width="150px"></asp:Label>
                                        </td>
                                        <td class="auto-style22">
                                            <asp:DropDownList ID="Cbomodalidad" runat="server" AutoPostBack="True" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style40">
                                            <asp:Label ID="Label65" runat="server" Height="16px" style="text-align: right" Text="Días" Width="150px"></asp:Label>
                                        </td>
                                        <td class="auto-style22">
                                            <asp:DropDownList ID="CboDias" runat="server" AutoPostBack="True" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style40">
                                            <asp:Label ID="Label51" runat="server" style="text-align: right" Text="Jornada" Width="150px"></asp:Label>
                                        </td>
                                        <td class="auto-style22">
                                            <asp:DropDownList ID="CboJornada0" runat="server" AutoPostBack="True" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style40">
                                            <asp:Label ID="Label69" runat="server" style="text-align: right" Text="Ciclo:" Width="150px"></asp:Label>
                                        </td>
                                        <td class="auto-style22">
                                            <asp:Label ID="lblnummat" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style40">&nbsp;</td>
                                        <td class="auto-style22">
                                            <asp:Button ID="CmdMatricularEstud" runat="server" Text="Agregar asignatura" Width="234px" />
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="auto-style20">
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6" DisplayAfter="100">
                                                <ProgressTemplate>
                                                    <img alt="" src="images/control.gif" style="width: 31px; height: 31px" />
                                                    Cargando las asignaturas.....
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Label ID="lbdetalletipmatri" runat="server" Height="16px" style="color: #800000; font-weight: 700; text-align: center; font-size: large" Width="850px"></asp:Label>
                                                    <br />
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="136px" style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; text-align: left;" Width="526px">
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <Columns>
                                                                        <asp:CommandField CancelText="Cancelar" DeleteText="Eliminar" EditText="Editar" HeaderText="Operaciones" ShowDeleteButton="True" Visible="False" />
                                                                        <asp:TemplateField HeaderText="Periodo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSemestre" runat="server" Text='<%# Bind("Detalle_Periodo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Asignatura">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblMateria" runat="server" style="text-align: left" Text='<%# Bind("Nomb_Materia") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Control R.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label68" runat="server" Text='<%#Eval("condicion") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Control C.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label70" runat="server" Text='<%#Eval("condicionv") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Button ID="cdmverasignatura" runat="server" Text="Ver asignaturas matriculado" Visible="False" Width="224px" />
                                                    <br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lblerrorGrid" runat="server" style="color: #800000; font-size: medium; font-family: Verdana"></asp:Label>
                                                    <asp:Label ID="lblcodperiodoacad" runat="server" Visible="False"></asp:Label>
                                                    <asp:Label ID="lblmensaje" runat="server" Visible="False"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="cdmNuevoEstud" runat="server" class="btn btn-primary" Text="Enviar datos" Visible="False" />
                                <asp:Label ID="lblmensajeactualizar" runat="server" style="font-style: italic; font-weight: 700; color: #990000" Visible="False"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="ImgImprimir" runat="server" ImageUrl="~/images/imprimirinscripcion.jpg" Visible="False" />
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/imprimematricula.png" NavigateUrl="~/ImprimirMatriculaIngles.aspx" Target="_blank">HyperLink</asp:HyperLink>
                                <br />
                                <asp:Label ID="LBLmensajeestud" runat="server" CssClass="auto-style3"></asp:Label>
                                <br />
                                <asp:Label ID="lblcodcarrera0" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LabelErrorcab0" runat="server"></asp:Label>
                                <asp:Label ID="lblcod_usu" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblusuario" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblperiodotipo" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcodasign" runat="server" style="font-size: small; font-family: Verdana" Visible="False"></asp:Label>
                                <asp:Label ID="lblmalla" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcodHorario" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcodmodalidad0" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcoddias" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LblNumCreditos" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lbltipoMatricula" runat="server" Visible="False">2</asp:Label>
                                <asp:Label ID="lblcontrolaprueba" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcsemestre" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblnivel" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcaprueba" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblvalorpago" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblcodjornada0" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblced" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lbljornada0" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblnumreg" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblnum" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="lblnumpago" runat="server" Visible="False"></asp:Label>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                </div>
            
    


                <div id="respuesta" style="display: none;"></div>
        </div>   
          
                      
    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../js/jquery.min.js"><\/script>')</script>
    <script src="../js/bootstrap.min.js"></script>
    <!-- Just to make our placeholder images work. Don't actually copy the next line! -->
    <script src="../js/holder.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../js/ie10-viewport-bug-workaround.js"></script>
                 
                                                <asp:Label ID="lblcod_us" runat="server"  Visible="False"></asp:Label>
    
                                                <asp:Label ID="lblcontrol" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblmensajeCed" runat="server" Visible="False"></asp:Label>
    
                                        <asp:Label ID="lblcodPeriodo" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="lblCodCarrera" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblcodestud" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="txtpas" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblnumestud" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblcontrolced" runat="server" Visible="False"></asp:Label>
    
                                                <asp:Label ID="lblcodModalidad" runat="server" Visible="False"></asp:Label>
    
                             
    
                                                </label>
    
                             
    
                                                <asp:Label ID="lblArchivo" runat="server" Visible="False"></asp:Label>
    
                             
    
                                                <asp:Label ID="lblnombCarrera" runat="server" Visible="False"></asp:Label>
    
                             
    
                                                <asp:Label ID="lblcodjornada" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lbljornada" runat="server" Visible="False"></asp:Label>
    
                             
      </div>

      <div class="col-sm-2" style="">
          <asp:Label ID="lblnumMatricula" runat="server" Visible="False"></asp:Label>
                    </div>

    </div>


                    </ContentTemplate>
          </asp:UpdatePanel>

         <script type = "text/javascript">
        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "Archivo cargado al sistema";
        }

        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "Error al subir";
        }
     
    </script>


                                                &nbsp;</form>
        </body>
</html>
