﻿// Copyright 2013-2018 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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

using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests.Coders
{
    [TestClass]
    public class TheJp2Coder
    {
        [TestMethod]
        public void ShouldReadTheImageWithCorrectDimensions()
        {
            using (IMagickImage image = new MagickImage(Files.Coders.GrimJp2))
            {
                Assert.AreEqual(2155, image.Width);
                Assert.AreEqual(2687, image.Height);
            }

            using (IMagickImage image = new MagickImage(Files.Coders.GrimJp2 + "[0]"))
            {
                Assert.AreEqual(2155, image.Width);
                Assert.AreEqual(2687, image.Height);
            }

            using (IMagickImage image = new MagickImage(Files.Coders.GrimJp2 + "[1]"))
            {
                Assert.AreEqual(256, image.Width);
                Assert.AreEqual(256, image.Height);
            }
        }
    }
}