using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class landingpurusstudiosamples : GXProcedure
   {
      public landingpurusstudiosamples( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public landingpurusstudiosamples( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem>( context, "SDTLandingPurusStudiosItem", "SsumarGroupDemo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> aP0_Gxm2rootcol )
      {
         landingpurusstudiosamples objlandingpurusstudiosamples;
         objlandingpurusstudiosamples = new landingpurusstudiosamples();
         objlandingpurusstudiosamples.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem>( context, "SDTLandingPurusStudiosItem", "SsumarGroupDemo") ;
         objlandingpurusstudiosamples.context.SetSubmitInitialConfig(context);
         objlandingpurusstudiosamples.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlandingpurusstudiosamples);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((landingpurusstudiosamples)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "f8d1c3ee-05ed-4c20-83c9-2b97c853bd95", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "Web";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "Evolution-oriented design of state-of-the-art applications";
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "fa3e9526-c548-4e7f-a527-60d7a1a233b1", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "UX/UI";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "User focused applications for a best experience";
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "a63f3b65-6f28-46db-9f10-b6460a9bb5d5", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "Mobile";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "Multi-platform native apps";
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "67877ab0-d93f-47ed-9449-70417e375baf", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "Cloud";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "Increased flexibility for your business applications in the cloud";
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "d45cbdb8-eddf-4ed1-9dc9-e1237b4423bb", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "BPM";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "Empowerment for the digitalization of corporate processes";
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "2706bbc9-b3eb-41da-9eba-e92a1195987a", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "SAP";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "Development of applications integrated with SAP";
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         Gxm2rootcol.Add(Gxm1sdtlandingpurusstudios, 0);
         Gxm1sdtlandingpurusstudios.gxTpr_Studioimage = context.convertURL( (string)(context.GetImagePath( "9ce6d594-0cbd-4e48-b270-8eed2f3d65f0", "", context.GetTheme( ))));
         Gxm1sdtlandingpurusstudios.gxTpr_Studiotitle = "BI";
         Gxm1sdtlandingpurusstudios.gxTpr_Studiodescription = "Transformation of business data into intelligence";
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gxm1sdtlandingpurusstudios = new GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem Gxm1sdtlandingpurusstudios ;
   }

}
