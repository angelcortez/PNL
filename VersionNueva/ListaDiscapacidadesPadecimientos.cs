using System;
using System.Collections;

namespace AtencionTemprana
{
    public class ListaDiscapacidadesPadecimientos
    {
        public ArrayList cargarPadecimientos()
        {
            ArrayList list = new ArrayList();
            list.Add("ALERGIAS");
            list.Add("ARTRITIS");
            list.Add("ASMA");
            list.Add("BRONQUITIS");
            list.Add("CIRROSIS");
            list.Add("DEPRESION");
            list.Add("DIABETES");
            list.Add("DROGADICCION");
            list.Add("ESQUIZOFRENIA");
            list.Add("GASTRITIS");
            list.Add("HEPATITIS");
            list.Add("HIPERTENSION");
            list.Add("MIGRAÑA");
            list.Add("NERVIOS");
            list.Add("PRESION Y DIABETES");
            list.Add("PRESION ARTERIAL ALTA");
            list.Add("PRESION ARTERIAL BAJA");
            list.Add("PSORIASIS");
            list.Add("RESPIRATORIO");
            list.Add("SINOCITIS CRONICA");
            list.Add("5 MESES DE GESTACION");

            return list;
        }


        public ArrayList cargarEnfermedadesSistematicas()
        {
            ArrayList list = new ArrayList();
            list.Add("AGORAFOBIA");
            list.Add("ANOREXIA NERVIOSA");
            list.Add("ANSIEDAD");
            list.Add("AUTISMO");
            list.Add("BRUXISMO");
            list.Add("BULIMIA");
            list.Add("COMPLEJO DE CULPABILIDAD");
            list.Add("COMPLEJO DE INFERIORIDAD");
            list.Add("COMPLEJO DE SUPERIORIDAD");
            list.Add("DEMENCIA");
            list.Add("DEPRESION");
            list.Add("EL PODER DEL NATIVE");
            list.Add("ESQUIZOFRENIA");
            list.Add("HISTERIA");
            list.Add("NEUROTICISMO");
            list.Add("PARALISIS CEREBRAL");
            list.Add("PSICOPATIA");
            list.Add("SINDROME DE DOWN");
            list.Add("TRASTORNO BIPOLAR");
            list.Add("TRASTORNO OBSESIVO COMPULSIVO");
            list.Add("VIGOREXIA");
            return list;
        }
    }
}
