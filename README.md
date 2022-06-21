# Azure-Function-Html2Pdf

Sample project to create a azure function in a docker container which converts HTML to PDF.

Most of the code come from an [article](https://www.freecodecamp.org/news/convert-html-to-pdf-with-azure-functions-and-wkhtmltopdf/) Arjav Dave.
I followed his instruction but was not able to copy the libwkhtmltox.so file, because the file system of the function was read-only.
I than decided to host the function in a docker container.
At first I still had some other issues but [this](https://github.com/rdvojmoc/DinkToPdf/issues/138) helped me to get it running.
