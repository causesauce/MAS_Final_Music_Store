using MAS_Final_Music_Store.DTOs;
using MAS_Final_Music_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly Context _context;
        public InstrumentRepository(Context context)
        {
            _context = context;
        }

        public Instrument CreateInstrument(IInstrument instrument)
        {
            Instrument newInstrument;
            switch (instrument)
            {
                case SamplingPad:
                    newInstrument = new SamplingPad();
                    break;

                case ElectricGuitar:
                    newInstrument = new ElectricGuitar();
                    break;

                case Violin:
                    newInstrument = new Violin();
                    break;

                case Guitar:
                    newInstrument = new Guitar();
                    break;

                default:
                    return null;
            }

            newInstrument.CopyData(instrument);
            _context.Instruments.Add(newInstrument);
            _context.SaveChanges();
            return newInstrument;
        }

        public List<Instrument> GetAllInstruments()
        {
            return _context.Instruments.ToList();
        }

        public List<Instrument> GetAllInstrumentsByBrand(int brandId)
        {
            return _context.Instruments.Where(i => i.BrandId == brandId).OrderBy(i => i.Name).ToList();
        }

        public List<InstrumentDto> GetAllInstrumentsOwnedByCustomer(int customerId)
        {
            List<Order> ordersOfCustomer = _context.Orders.AsNoTracking()
                                                    .Where(o => o.CustomerId == customerId)
                                                    .ToList();


            List<InstrumentDto> instrumentDtos = new();
            foreach(var order in ordersOfCustomer)
            {
                var instrumentDtosTmp = _context.OrderInstruments.AsNoTracking()
                                            .Where(oi => oi.OrderId == order.OrderId)
                                            .Include(oi => oi.InstrumentIdNavigation)
                                            .Select(
                                                oi => new InstrumentDto
                                                {
                                                    InstrumentId = oi.InstrumentIdNavigation.InstrumentId,
                                                    Name = oi.InstrumentIdNavigation.Name,
                                                    DateLastPurchase = order.Date
                                                }
                                            ).ToList();
                instrumentDtos.AddRange(instrumentDtosTmp);
            }

            instrumentDtos = instrumentDtos.OrderBy(i => i.DateLastPurchase).GroupBy(i => i.InstrumentId).Select(group => group.First()).ToList();
            return instrumentDtos;
        }

        public Instrument GetInstrumentById(int id)
        {
            return _context.Instruments.Where(i => i.InstrumentId == id).FirstOrDefault();
        }

        public bool RemoveInstrument(int id)
        {
            var instrument = GetInstrumentById(id);
            if(instrument is null)
            {
                return false;
            }

            _context.Instruments.Remove(instrument);
            _context.SaveChanges();
            return true;
        }

        public Instrument UpdateInstrument(int id, IInstrument instrument)
        {
            Instrument editedInstrument;
            var neededInstrument = GetInstrumentById(id);
            if(instrument.GetType() != neededInstrument.GetType())
            {
                return null;
            }
            
            switch (instrument)
            {
                case SamplingPad:
                    editedInstrument = (SamplingPad)neededInstrument;
                    break;

                case ElectricGuitar:
                    editedInstrument = (ElectricGuitar)neededInstrument;
                    break;

                case Violin:
                    editedInstrument = (Violin)neededInstrument;
                    break;

                case Guitar:
                    editedInstrument = (Guitar)neededInstrument;
                    break;

                default:
                    return null;
            }

            editedInstrument.CopyData(instrument);
            _context.SaveChanges();
            return editedInstrument;
        }
    }
}
