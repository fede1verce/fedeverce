using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class servicios : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public servicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public servicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Customersgrid") == 0 )
            {
               nRC_GXsfl_21 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_21"), "."));
               nGXsfl_21_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_21_idx"), "."));
               sGXsfl_21_idx = GetPar( "sGXsfl_21_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrCustomersgrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Customersgrid") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrCustomersgrid_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fstestimonials") == 0 )
            {
               nRC_GXsfl_35 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."));
               nGXsfl_35_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."));
               sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrFstestimonials_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fstestimonials") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrFstestimonials_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0R2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2155220), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2155220), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2155220), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202191519265942", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.servicios.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdthometestimonials", AV6SDTHomeTestimonials);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdthometestimonials", AV6SDTHomeTestimonials);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdthomelandingsamplelogos", AV5SDTHomeLandingSampleLogos);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdthomelandingsamplelogos", AV5SDTHomeLandingSampleLogos);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_21", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_21), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Class", StringUtil.RTrim( subCustomersgrid_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Flexwrap", StringUtil.RTrim( subCustomersgrid_Flexwrap));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Justifycontent", StringUtil.RTrim( subCustomersgrid_Justifycontent));
         GxWebStd.gx_hidden_field( context, "FSTESTIMONIALS_Class", StringUtil.RTrim( subFstestimonials_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0R2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwpbaseobjects.servicios.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Servicios" ;
      }

      public override string GetPgmdesc( )
      {
         return "Servicios" ;
      }

      protected void WB0R0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusCustomersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeadersection_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCustomerstitle_Internalname, "Servicios", "", "", lblCustomerstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhite", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Servicios.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom50", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientssection_Internalname, 1, 0, "px", 0, "px", "TableContentLandingPurusHorizontalGrid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom50 CellPaddingTop80", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCustomersinfo_Internalname, "Some of the companies that have relied on us", "", "", lblCustomersinfo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleGray", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Servicios.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            CustomersgridContainer.SetIsFreestyle(true);
            CustomersgridContainer.SetWrapped(nGXWrapped);
            if ( CustomersgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"CustomersgridContainer"+"DivS\" data-gxgridid=\"21\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subCustomersgrid_Internalname, subCustomersgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               CustomersgridContainer.AddObjectProperty("GridName", "Customersgrid");
            }
            else
            {
               CustomersgridContainer.AddObjectProperty("GridName", "Customersgrid");
               CustomersgridContainer.AddObjectProperty("Header", subCustomersgrid_Header);
               CustomersgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               CustomersgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               CustomersgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Backcolorstyle), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("CmpContext", "");
               CustomersgridContainer.AddObjectProperty("InMasterPage", "false");
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthomelandingsamplelogos__logo_Enabled), 5, 0, ".", "")));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Selectedindex), 4, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Allowselection), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Selectioncolor), 9, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Allowhovering), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Hoveringcolor), 9, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Allowcollapsing), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            nRC_GXsfl_21 = (int)(nGXsfl_21_idx-1);
            if ( CustomersgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV10GXV1 = nGXsfl_21_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"CustomersgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Customersgrid", CustomersgridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CustomersgridContainerData", CustomersgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CustomersgridContainerData"+"V", CustomersgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CustomersgridContainerData"+"V"+"\" value='"+CustomersgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusTestimonialsCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTestimonialssection_Internalname, 1, 0, "px", 0, "px", "TableContentLandingPurusTestimonials", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTestimonialstitle_Internalname, "Testimonials", "", "", lblTestimonialstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhiteWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Servicios.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "left", "top", "", "", "div");
            /*  Grid Control  */
            FstestimonialsContainer.SetIsFreestyle(true);
            FstestimonialsContainer.SetWrapped(nGXWrapped);
            if ( FstestimonialsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"DivS\" data-gxgridid=\"35\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subFstestimonials_Internalname, subFstestimonials_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
            }
            else
            {
               FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
               FstestimonialsContainer.AddObjectProperty("Header", subFstestimonials_Header);
               FstestimonialsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               FstestimonialsContainer.AddObjectProperty("Class", "FreeStyleGrid");
               FstestimonialsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Backcolorstyle), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("CmpContext", "");
               FstestimonialsContainer.AddObjectProperty("InMasterPage", "false");
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Selectedindex), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowselection), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Selectioncolor), 9, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowhovering), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Hoveringcolor), 9, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowcollapsing), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( FstestimonialsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV12GXV3 = nGXsfl_35_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fstestimonials", FstestimonialsContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData", FstestimonialsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData"+"V", FstestimonialsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FstestimonialsContainerData"+"V"+"\" value='"+FstestimonialsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( CustomersgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV10GXV1 = nGXsfl_21_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"CustomersgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Customersgrid", CustomersgridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CustomersgridContainerData", CustomersgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CustomersgridContainerData"+"V", CustomersgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CustomersgridContainerData"+"V"+"\" value='"+CustomersgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FstestimonialsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV12GXV3 = nGXsfl_35_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fstestimonials", FstestimonialsContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData", FstestimonialsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData"+"V", FstestimonialsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FstestimonialsContainerData"+"V"+"\" value='"+FstestimonialsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0R2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148375", 0) ;
            }
            Form.Meta.addItem("description", "Servicios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0R0( ) ;
      }

      protected void WS0R2( )
      {
         START0R2( ) ;
         EVT0R2( ) ;
      }

      protected void EVT0R2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "CUSTOMERSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_21_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
                              SubsflControlProps_212( ) ;
                              AV10GXV1 = nGXsfl_21_idx;
                              if ( ( AV5SDTHomeLandingSampleLogos.Count >= AV10GXV1 ) && ( AV10GXV1 > 0 ) )
                              {
                                 AV5SDTHomeLandingSampleLogos.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV5SDTHomeLandingSampleLogos.Item(AV10GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CUSTOMERSGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E120R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FSTESTIMONIALS.LOAD") == 0 )
                           {
                              nGXsfl_35_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_353( ) ;
                              AV12GXV3 = nGXsfl_35_idx;
                              if ( ( AV6SDTHomeTestimonials.Count >= AV12GXV3 ) && ( AV12GXV3 > 0 ) )
                              {
                                 AV6SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV12GXV3));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FSTESTIMONIALS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E130R3 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0R2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrCustomersgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_212( ) ;
         while ( nGXsfl_21_idx <= nRC_GXsfl_21 )
         {
            sendrow_212( ) ;
            nGXsfl_21_idx = ((subCustomersgrid_Islastpage==1)&&(nGXsfl_21_idx+1>subCustomersgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CustomersgridContainer)) ;
         /* End function gxnrCustomersgrid_newrow */
      }

      protected void gxnrFstestimonials_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_353( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_353( ) ;
            nGXsfl_35_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_35_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_353( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FstestimonialsContainer)) ;
         /* End function gxnrFstestimonials_newrow */
      }

      protected void gxgrCustomersgrid_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         CUSTOMERSGRID_nCurrentRecord = 0;
         RF0R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCustomersgrid_refresh */
      }

      protected void gxgrFstestimonials_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSTESTIMONIALS_nCurrentRecord = 0;
         RF0R3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFstestimonials_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0R2( ) ;
         RF0R3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialscompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0), !bGXsfl_35_Refreshing);
      }

      protected void RF0R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CustomersgridContainer.ClearRows();
         }
         wbStart = 21;
         nGXsfl_21_idx = 1;
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         bGXsfl_21_Refreshing = true;
         CustomersgridContainer.AddObjectProperty("GridName", "Customersgrid");
         CustomersgridContainer.AddObjectProperty("CmpContext", "");
         CustomersgridContainer.AddObjectProperty("InMasterPage", "false");
         CustomersgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         CustomersgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         CustomersgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CustomersgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         CustomersgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Backcolorstyle), 1, 0, ".", "")));
         CustomersgridContainer.PageSize = subCustomersgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_212( ) ;
            E120R2 ();
            wbEnd = 21;
            WB0R0( ) ;
         }
         bGXsfl_21_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0R2( )
      {
      }

      protected void RF0R3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FstestimonialsContainer.ClearRows();
         }
         wbStart = 35;
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_353( ) ;
         bGXsfl_35_Refreshing = true;
         FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
         FstestimonialsContainer.AddObjectProperty("CmpContext", "");
         FstestimonialsContainer.AddObjectProperty("InMasterPage", "false");
         FstestimonialsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FstestimonialsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FstestimonialsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FstestimonialsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FstestimonialsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Backcolorstyle), 1, 0, ".", "")));
         FstestimonialsContainer.PageSize = subFstestimonials_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_353( ) ;
            E130R3 ();
            wbEnd = 35;
            WB0R0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0R3( )
      {
      }

      protected int subCustomersgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialscompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdthometestimonials"), AV6SDTHomeTestimonials);
            ajax_req_read_hidden_sdt(cgiGet( "Sdthomelandingsamplelogos"), AV5SDTHomeLandingSampleLogos);
            /* Read saved values. */
            nRC_GXsfl_21 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_21"), ",", "."));
            nRC_GXsfl_35 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ",", "."));
            subCustomersgrid_Class = cgiGet( "CUSTOMERSGRID_Class");
            subCustomersgrid_Flexwrap = cgiGet( "CUSTOMERSGRID_Flexwrap");
            subCustomersgrid_Justifycontent = cgiGet( "CUSTOMERSGRID_Justifycontent");
            subFstestimonials_Class = cgiGet( "FSTESTIMONIALS_Class");
            nRC_GXsfl_21 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_21"), ",", "."));
            nGXsfl_21_fel_idx = 0;
            while ( nGXsfl_21_fel_idx < nRC_GXsfl_21 )
            {
               nGXsfl_21_fel_idx = ((subCustomersgrid_Islastpage==1)&&(nGXsfl_21_fel_idx+1>subCustomersgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_fel_idx+1);
               sGXsfl_21_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_212( ) ;
               AV10GXV1 = nGXsfl_21_fel_idx;
               if ( ( AV5SDTHomeLandingSampleLogos.Count >= AV10GXV1 ) && ( AV10GXV1 > 0 ) )
               {
                  AV5SDTHomeLandingSampleLogos.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV5SDTHomeLandingSampleLogos.Item(AV10GXV1));
               }
            }
            if ( nGXsfl_21_fel_idx == 0 )
            {
               nGXsfl_21_idx = 1;
               sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
               SubsflControlProps_212( ) ;
            }
            nGXsfl_21_fel_idx = 1;
            nRC_GXsfl_35 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ",", "."));
            nGXsfl_35_fel_idx = 0;
            while ( nGXsfl_35_fel_idx < nRC_GXsfl_35 )
            {
               nGXsfl_35_fel_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_35_fel_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_fel_idx+1);
               sGXsfl_35_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_353( ) ;
               AV12GXV3 = nGXsfl_35_fel_idx;
               if ( ( AV6SDTHomeTestimonials.Count >= AV12GXV3 ) && ( AV12GXV3 > 0 ) )
               {
                  AV6SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV12GXV3));
               }
            }
            if ( nGXsfl_35_fel_idx == 0 )
            {
               nGXsfl_35_idx = 1;
               sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
               SubsflControlProps_353( ) ;
            }
            nGXsfl_35_fel_idx = 1;
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110R2 ();
         if (returnInSub) return;
      }

      protected void E110R2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1 = AV5SDTHomeLandingSampleLogos;
         new GeneXus.Programs.wwpbaseobjects.homelandingcustomerlogos(context ).execute( out  GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1) ;
         AV5SDTHomeLandingSampleLogos = GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1;
         gx_BV21 = true;
         GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 = AV6SDTHomeTestimonials;
         new GeneXus.Programs.wwpbaseobjects.hometestimonials(context ).execute( out  GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2) ;
         AV6SDTHomeTestimonials = GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2;
         gx_BV35 = true;
         AV7WebSession.Set("IsLandingPage", "S");
      }

      private void E120R2( )
      {
         /* Customersgrid_Load Routine */
         returnInSub = false;
         AV10GXV1 = 1;
         while ( AV10GXV1 <= AV5SDTHomeLandingSampleLogos.Count )
         {
            AV5SDTHomeLandingSampleLogos.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV5SDTHomeLandingSampleLogos.Item(AV10GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 21;
            }
            sendrow_212( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_21_Refreshing )
            {
               context.DoAjaxLoad(21, CustomersgridRow);
            }
            AV10GXV1 = (int)(AV10GXV1+1);
         }
      }

      private void E130R3( )
      {
         /* Fstestimonials_Load Routine */
         returnInSub = false;
         AV12GXV3 = 1;
         while ( AV12GXV3 <= AV6SDTHomeTestimonials.Count )
         {
            AV6SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV12GXV3));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 35;
            }
            sendrow_353( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
            {
               context.DoAjaxLoad(35, FstestimonialsRow);
            }
            AV12GXV3 = (int)(AV12GXV3+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0R2( ) ;
         WS0R2( ) ;
         WE0R2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202191519265991", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwpbaseobjects/servicios.js", "?202191519265991", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_212( )
      {
         edtavSdthomelandingsamplelogos__logo_Internalname = "SDTHOMELANDINGSAMPLELOGOS__LOGO_"+sGXsfl_21_idx;
      }

      protected void SubsflControlProps_fel_212( )
      {
         edtavSdthomelandingsamplelogos__logo_Internalname = "SDTHOMELANDINGSAMPLELOGOS__LOGO_"+sGXsfl_21_fel_idx;
      }

      protected void sendrow_212( )
      {
         SubsflControlProps_212( ) ;
         WB0R0( ) ;
         CustomersgridRow = GXWebRow.GetNew(context,CustomersgridContainer);
         if ( subCustomersgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subCustomersgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Odd";
            }
         }
         else if ( subCustomersgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subCustomersgrid_Backstyle = 0;
            subCustomersgrid_Backcolor = subCustomersgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Uniform";
            }
         }
         else if ( subCustomersgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subCustomersgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Odd";
            }
            subCustomersgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subCustomersgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subCustomersgrid_Backstyle = 1;
            subCustomersgrid_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         CustomersgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefscustomersgrid_Internalname+"_"+sGXsfl_21_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Div Control */
         CustomersgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Div Control */
         CustomersgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Div Control */
         CustomersgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Attribute/Variable Label */
         CustomersgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Logo",(string)"col-sm-3 AttributeLandingPurusCustomersImageLabel",(short)0,(bool)true,(string)""});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Static Bitmap Variable */
         ClassString = "AttributeLandingPurusCustomersImage";
         StyleString = "";
         sImgUrl = context.PathToRelativeUrl( ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV5SDTHomeLandingSampleLogos.Item(AV10GXV1)).gxTpr_Logo);
         CustomersgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthomelandingsamplelogos__logo_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(int)edtavSdthomelandingsamplelogos__logo_Enabled,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         send_integrity_lvl_hashes0R2( ) ;
         /* End of Columns property logic. */
         CustomersgridContainer.AddRow(CustomersgridRow);
         nGXsfl_21_idx = ((subCustomersgrid_Islastpage==1)&&(nGXsfl_21_idx+1>subCustomersgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         /* End function sendrow_212 */
      }

      protected void SubsflControlProps_353( )
      {
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION_"+sGXsfl_35_idx;
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME_"+sGXsfl_35_idx;
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_353( )
      {
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION_"+sGXsfl_35_fel_idx;
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME_"+sGXsfl_35_fel_idx;
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_353( )
      {
         SubsflControlProps_353( ) ;
         WB0R0( ) ;
         FstestimonialsRow = GXWebRow.GetNew(context,FstestimonialsContainer);
         if ( subFstestimonials_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFstestimonials_Backstyle = 0;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
            }
         }
         else if ( subFstestimonials_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFstestimonials_Backstyle = 0;
            subFstestimonials_Backcolor = subFstestimonials_Allbackcolor;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Uniform";
            }
         }
         else if ( subFstestimonials_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFstestimonials_Backstyle = 1;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
            }
            subFstestimonials_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFstestimonials_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFstestimonials_Backstyle = 1;
            if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
            {
               subFstestimonials_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
               {
                  subFstestimonials_Linesclass = subFstestimonials_Class+"Even";
               }
            }
            else
            {
               subFstestimonials_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
               {
                  subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FstestimonialsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFstestimonials_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_35_idx+"\">") ;
         }
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsfstestimonials_Internalname+"_"+sGXsfl_35_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 TableLandingPurusTestimonials",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsdescription_Internalname,(string)"SDTHome Testimonials Description",(string)"col-sm-3 AttributeLandingPurusTestimonialDescriptionLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Multiple line edit */
         ClassString = "AttributeLandingPurusTestimonialDescription";
         StyleString = "";
         ClassString = "AttributeLandingPurusTestimonialDescription";
         StyleString = "";
         FstestimonialsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV12GXV3)).gxTpr_Sdthometestimonialsdescription,(string)"",(string)"",(short)0,(short)1,(int)edtavSdthometestimonials__sdthometestimonialsdescription_Enabled,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)false,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 LandingPurusTestimonialTitleCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_35_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsname_Internalname,(string)"SDTHome Testimonials Name",(string)"col-sm-3 AttributeLandingPurusTestimonialTitleLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusTestimonialTitle";
         FstestimonialsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsname_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV12GXV3)).gxTpr_Sdthometestimonialsname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdthometestimonials__sdthometestimonialsname_Jsonclick,(short)0,(string)"AttributeLandingPurusTestimonialTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdthometestimonials__sdthometestimonialsname_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)35,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialscompany_Internalname,(string)"SDTHome Testimonials Company",(string)"col-sm-3 AttributeLandingPurusTestimonialSubtitleLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusTestimonialSubtitle";
         FstestimonialsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialscompany_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV12GXV3)).gxTpr_Sdthometestimonialscompany,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick,(short)0,(string)"AttributeLandingPurusTestimonialSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdthometestimonials__sdthometestimonialscompany_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)35,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         send_integrity_lvl_hashes0R3( ) ;
         /* End of Columns property logic. */
         FstestimonialsContainer.AddRow(FstestimonialsRow);
         nGXsfl_35_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_35_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_353( ) ;
         /* End function sendrow_353 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblCustomerstitle_Internalname = "CUSTOMERSTITLE";
         divHeadersection_Internalname = "HEADERSECTION";
         lblCustomersinfo_Internalname = "CUSTOMERSINFO";
         edtavSdthomelandingsamplelogos__logo_Internalname = "SDTHOMELANDINGSAMPLELOGOS__LOGO";
         divUnnamedtablefscustomersgrid_Internalname = "UNNAMEDTABLEFSCUSTOMERSGRID";
         divClientssection_Internalname = "CLIENTSSECTION";
         lblTestimonialstitle_Internalname = "TESTIMONIALSTITLE";
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION";
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME";
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divUnnamedtablefsfstestimonials_Internalname = "UNNAMEDTABLEFSFSTESTIMONIALS";
         divTestimonialssection_Internalname = "TESTIMONIALSSECTION";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subCustomersgrid_Internalname = "CUSTOMERSGRID";
         subFstestimonials_Internalname = "FSTESTIMONIALS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick = "";
         edtavSdthometestimonials__sdthometestimonialsname_Jsonclick = "";
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = -1;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = -1;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = -1;
         subFstestimonials_Allowcollapsing = 0;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         subFstestimonials_Backcolorstyle = 0;
         subCustomersgrid_Allowcollapsing = 0;
         edtavSdthomelandingsamplelogos__logo_Enabled = 0;
         subCustomersgrid_Backcolorstyle = 0;
         subFstestimonials_Class = "FreeStyleGrid";
         subCustomersgrid_Justifycontent = "space-around";
         subCustomersgrid_Flexwrap = "wrap";
         subCustomersgrid_Class = "FreeStyleGrid";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Servicios";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'CUSTOMERSGRID_nFirstRecordOnPage'},{av:'CUSTOMERSGRID_nEOF'},{av:'AV5SDTHomeLandingSampleLogos',fld:'vSDTHOMELANDINGSAMPLELOGOS',grid:21,pic:''},{av:'nRC_GXsfl_21',ctrl:'CUSTOMERSGRID',prop:'GridRC'},{av:'FSTESTIMONIALS_nFirstRecordOnPage'},{av:'FSTESTIMONIALS_nEOF'},{av:'AV6SDTHomeTestimonials',fld:'vSDTHOMETESTIMONIALS',grid:35,pic:''},{av:'nRC_GXsfl_35',ctrl:'FSTESTIMONIALS',prop:'GridRC'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("FSTESTIMONIALS.LOAD","{handler:'E130R3',iparms:[]");
         setEventMetadata("FSTESTIMONIALS.LOAD",",oparms:[]}");
         setEventMetadata("CUSTOMERSGRID.LOAD","{handler:'E120R2',iparms:[]");
         setEventMetadata("CUSTOMERSGRID.LOAD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv2',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6SDTHomeTestimonials = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo");
         AV5SDTHomeLandingSampleLogos = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem>( context, "SDTHomeLandingSampleLogosItem", "SsumarGroupDemo");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblCustomerstitle_Jsonclick = "";
         lblCustomersinfo_Jsonclick = "";
         CustomersgridContainer = new GXWebGrid( context);
         sStyleString = "";
         subCustomersgrid_Header = "";
         CustomersgridColumn = new GXWebColumn();
         lblTestimonialstitle_Jsonclick = "";
         FstestimonialsContainer = new GXWebGrid( context);
         subFstestimonials_Header = "";
         FstestimonialsColumn = new GXWebColumn();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem>( context, "SDTHomeLandingSampleLogosItem", "SsumarGroupDemo");
         GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo");
         AV7WebSession = context.GetSession();
         CustomersgridRow = new GXWebRow();
         FstestimonialsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subCustomersgrid_Linesclass = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         subFstestimonials_Linesclass = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subCustomersgrid_Backcolorstyle ;
      private short subCustomersgrid_Allowselection ;
      private short subCustomersgrid_Allowhovering ;
      private short subCustomersgrid_Allowcollapsing ;
      private short subCustomersgrid_Collapsed ;
      private short subFstestimonials_Backcolorstyle ;
      private short subFstestimonials_Allowselection ;
      private short subFstestimonials_Allowhovering ;
      private short subFstestimonials_Allowcollapsing ;
      private short subFstestimonials_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subCustomersgrid_Backstyle ;
      private short subFstestimonials_Backstyle ;
      private short CUSTOMERSGRID_nEOF ;
      private short FSTESTIMONIALS_nEOF ;
      private int nRC_GXsfl_21 ;
      private int nRC_GXsfl_35 ;
      private int nGXsfl_21_idx=1 ;
      private int nGXsfl_35_idx=1 ;
      private int edtavSdthomelandingsamplelogos__logo_Enabled ;
      private int subCustomersgrid_Selectedindex ;
      private int subCustomersgrid_Selectioncolor ;
      private int subCustomersgrid_Hoveringcolor ;
      private int AV10GXV1 ;
      private int edtavSdthometestimonials__sdthometestimonialsdescription_Enabled ;
      private int edtavSdthometestimonials__sdthometestimonialsname_Enabled ;
      private int edtavSdthometestimonials__sdthometestimonialscompany_Enabled ;
      private int subFstestimonials_Selectedindex ;
      private int subFstestimonials_Selectioncolor ;
      private int subFstestimonials_Hoveringcolor ;
      private int AV12GXV3 ;
      private int subCustomersgrid_Islastpage ;
      private int subFstestimonials_Islastpage ;
      private int nGXsfl_21_fel_idx=1 ;
      private int nGXsfl_35_fel_idx=1 ;
      private int idxLst ;
      private int subCustomersgrid_Backcolor ;
      private int subCustomersgrid_Allbackcolor ;
      private int subFstestimonials_Backcolor ;
      private int subFstestimonials_Allbackcolor ;
      private long CUSTOMERSGRID_nCurrentRecord ;
      private long FSTESTIMONIALS_nCurrentRecord ;
      private long CUSTOMERSGRID_nFirstRecordOnPage ;
      private long FSTESTIMONIALS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_21_idx="0001" ;
      private string sGXsfl_35_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subCustomersgrid_Class ;
      private string subCustomersgrid_Flexwrap ;
      private string subCustomersgrid_Justifycontent ;
      private string subFstestimonials_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divHeadersection_Internalname ;
      private string lblCustomerstitle_Internalname ;
      private string lblCustomerstitle_Jsonclick ;
      private string divClientssection_Internalname ;
      private string lblCustomersinfo_Internalname ;
      private string lblCustomersinfo_Jsonclick ;
      private string sStyleString ;
      private string subCustomersgrid_Internalname ;
      private string subCustomersgrid_Header ;
      private string divTestimonialssection_Internalname ;
      private string lblTestimonialstitle_Internalname ;
      private string lblTestimonialstitle_Jsonclick ;
      private string subFstestimonials_Internalname ;
      private string subFstestimonials_Header ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavSdthometestimonials__sdthometestimonialsdescription_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialsname_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialscompany_Internalname ;
      private string sGXsfl_21_fel_idx="0001" ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string edtavSdthomelandingsamplelogos__logo_Internalname ;
      private string subCustomersgrid_Linesclass ;
      private string divUnnamedtablefscustomersgrid_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string subFstestimonials_Linesclass ;
      private string divUnnamedtablefsfstestimonials_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string ROClassString ;
      private string edtavSdthometestimonials__sdthometestimonialsname_Jsonclick ;
      private string edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool bGXsfl_21_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV21 ;
      private bool gx_BV35 ;
      private GXWebGrid CustomersgridContainer ;
      private GXWebGrid FstestimonialsContainer ;
      private GXWebRow CustomersgridRow ;
      private GXWebRow FstestimonialsRow ;
      private GXWebColumn CustomersgridColumn ;
      private GXWebColumn FstestimonialsColumn ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV7WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem> AV5SDTHomeLandingSampleLogos ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem> GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> AV6SDTHomeTestimonials ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 ;
      private GXWebForm Form ;
   }

}
