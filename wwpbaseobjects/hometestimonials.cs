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
   public class hometestimonials : GXProcedure
   {
      public hometestimonials( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public hometestimonials( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> aP0_Gxm2rootcol )
      {
         hometestimonials objhometestimonials;
         objhometestimonials = new hometestimonials();
         objhometestimonials.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo") ;
         objhometestimonials.context.SetSubmitInitialConfig(context);
         objhometestimonials.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objhometestimonials);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((hometestimonials)stateInfo).executePrivate();
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
         Gxm1sdthometestimonials = new GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem(context);
         Gxm2rootcol.Add(Gxm1sdthometestimonials, 0);
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsname = "Dino Vidili";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialscompany = "Managing Director";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsdescription = "\"Ssumar Group nace como una Red Multidisciplinaria y Colaborativa de Expertos con +10 años de Experiencia en Senior Management\"";
         Gxm1sdthometestimonials = new GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem(context);
         Gxm2rootcol.Add(Gxm1sdthometestimonials, 0);
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsname = "Diego Gonzalez";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialscompany = "Area Proyectos e innovacion";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsdescription = "“Dado el actual contexto Post-Pandemia vemos un mercado insatisfecho en el ámbito de Pequeñas y Medianas Empresas en materia de expertise técnico y herramientas de gestión y tecnología para, mediante bases sólidas, mejorar y sostener resultados\".";
         Gxm1sdthometestimonials = new GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem(context);
         Gxm2rootcol.Add(Gxm1sdthometestimonials, 0);
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsname = "Claudio Tome";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialscompany = "Area Operaciones y Optimizacion de Procesos";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsdescription = "\".Visión Integral del Negocio objetivo y Planeamiento Estratégico\"";
         Gxm1sdthometestimonials = new GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem(context);
         Gxm2rootcol.Add(Gxm1sdthometestimonials, 0);
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsname = "Martin Crescimone";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialscompany = "Area Supply Chain & Negocios Internacionales";
         Gxm1sdthometestimonials.gxTpr_Sdthometestimonialsdescription = "\".Gestión de Proyectos y Riesgos.Tecnología como aliada y Socia de Negocios\"";
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
         Gxm1sdthometestimonials = new GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem Gxm1sdthometestimonials ;
   }

}
