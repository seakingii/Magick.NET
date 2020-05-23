﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using System.Collections.Generic;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace Magick.NET.Tests
{
    public partial class SafePixelCollectionTests
    {
        [TestClass]
        public class TheSetAreaMethod
        {
            [TestMethod]
            public void ShouldThrowExceptionWhenByteArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, (byte[])null);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenByteArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, new byte[] { 0, 0, 0, 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenByteArrayHasTooManyValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            var values = new byte[(113 * 108 * image.ChannelCount) + image.ChannelCount];
                            pixels.SetArea(10, 10, 113, 108, values);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenByteArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new byte[113 * 108 * image.ChannelCount];
                        pixels.SetArea(10, 10, 113, 108, values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenByteArrayIsSpecifiedAndGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            pixels.SetArea(null, new byte[] { 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenGeometryAndByteArrayAreSpecified()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new byte[113 * 108 * image.ChannelCount];
                        pixels.SetArea(new MagickGeometry(10, 10, 113, 108), values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenDoubleArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, (double[])null);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenDoubleArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, new double[] { 0, 0, 0, 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenDoubleArrayHasTooManyValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            var values = new double[(113 * 108 * image.ChannelCount) + image.ChannelCount];
                            pixels.SetArea(10, 10, 113, 108, values);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenDoubleArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new double[113 * 108 * image.ChannelCount];
                        pixels.SetArea(10, 10, 113, 108, values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenDoubleArrayIsSpecifiedAndGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            pixels.SetArea(null, new double[] { 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenGeometryAndDoubleArrayAreSpecified()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new double[113 * 108 * image.ChannelCount];
                        pixels.SetArea(new MagickGeometry(10, 10, 113, 108), values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenIntArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, (int[])null);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenIntArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, new int[] { 0, 0, 0, 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenIntArrayHasTooManyValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            var values = new int[(113 * 108 * image.ChannelCount) + image.ChannelCount];
                            pixels.SetArea(10, 10, 113, 108, values);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenIntArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new int[113 * 108 * image.ChannelCount];
                        pixels.SetArea(10, 10, 113, 108, values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenIntArrayIsSpecifiedAndGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            pixels.SetArea(null, new int[] { 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenGeometryAndIntArrayAreSpecified()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new int[113 * 108 * image.ChannelCount];
                        pixels.SetArea(new MagickGeometry(10, 10, 113, 108), values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, (QuantumType[])null);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            pixels.SetArea(10, 10, 1000, 1000, new QuantumType[] { 0, 0, 0, 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenArrayHasTooManyValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentException>("values", () =>
                        {
                            var values = new QuantumType[(113 * 108 * image.ChannelCount) + image.ChannelCount];
                            pixels.SetArea(10, 10, 113, 108, values);
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new QuantumType[113 * 108 * image.ChannelCount];
                        pixels.SetArea(10, 10, 113, 108, values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenArrayIsSpecifiedAndGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("geometry", () =>
                        {
                            pixels.SetArea(null, new QuantumType[] { 0 });
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldChangePixelsWhenGeometryAndArrayAreSpecified()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (IPixelCollection pixels = image.GetPixels())
                    {
                        var values = new QuantumType[113 * 108 * image.ChannelCount];
                        pixels.SetArea(new MagickGeometry(10, 10, 113, 108), values);

                        ColorAssert.AreEqual(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }
        }
    }
}
