from datetime import date
fecha = date.today()
BOLETIN_STAFE_URL = "https://www.santafe.gov.ar/boletinoficial/ver.php?seccion=" + str(fecha.year) + "/" + str(fecha) + "contratos.html"
BOLETIN_ARG_URL = "https://www.boletinoficial.gob.ar/seccion/segunda"
