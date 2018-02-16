using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriaCultura_service.Models
{
    public class Repository
    {
        private static triaculturaCTXEntities dataContext = new ChinookEntities();
        public static List<Invoice> GetInvoicesClient(int client_id, bool serialize)
        {
            List<Invoice> li = dataContext.Invoices.Where(x => x.CustomerId == client_id).ToList();
            foreach (Invoice factura in li)
            {
                factura.SerializeVirtualProperties = serialize;
            }
            return li;
        }

        public static List<Invoice> GetInvoices(int start, int end, bool serialize)
        {
            List<Invoice> li = dataContext.Invoices.Where(x => x.InvoiceId >= start && x.InvoiceId <= end).ToList();
            foreach (Invoice factura in li)
            {
                factura.SerializeVirtualProperties = serialize;
            }
            return li;
        }

        public static List<Invoice> GetInvoicesTrack(int track_id, bool serialize)
        {
            List<InvoiceLine> aux_list = dataContext.InvoiceLines.Where(x => x.TrackId == track_id).ToList();
            List<Invoice> li = new List<Invoice>();
            foreach (InvoiceLine line in aux_list)
            {
                if (!li.Contains(line.Invoice))
                {
                    li.Add(line.Invoice);
                }
            }
            foreach (Invoice factura in li)
            {
                factura.SerializeVirtualProperties = serialize;
            }
            return li;

        }
    }