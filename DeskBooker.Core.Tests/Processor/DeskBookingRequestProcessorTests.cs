﻿using System;
using DeskBooker.Core.Domain;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
             _processor = new DeskBookingRequestProcessor();
        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequstValues()
        {
            //Arrange
            var request = new DeskBookingRequest
            {
                FirstName = "Oluwatobi",
                LastName = "Akinseye",
                Email = "tobi.akinseye@gmail.com",
                Date = new DateTime(2020, 01, 28)

            };

            //Act
           
           DeskBookingResult result = _processor.BookDesk(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowAnExceptionIfRequestIsNull()
        {
            
             var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }
    }
}
