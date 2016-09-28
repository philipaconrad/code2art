// code2art.fs -- An fsharp rendition of my favorite text -> image program.
// Copyright (c) Philip Conrad, 2016. All rights reserved.
// Released under terms of the MIT License. (See LICENSE for details)

open System
open System.Drawing
open System.IO
open System.Collections

let readLines filePath = File.ReadAllLines(filePath);;


[<EntryPoint>]
let main (argv:string array) =
    for filename in argv do
        // Read in file as list of lines.
        let lines = readLines filename
        let longest = Seq.max (seq { for line in lines -> line.Length })
        let x_px = longest
        let y_px = lines.Length

        // Create a blank bitmap.
        let img = new Bitmap(x_px, y_px, Imaging.PixelFormat.Format16bppRgb555)
        printf "Rendering %s with dimensions (%A, %A)\n" filename x_px y_px

        // Set all BG pixels to white.
        for i = 0 to (img.Width-1) do
            for j = 0 to (img.Height-1) do
                img.SetPixel(i, j, Color.White)

        // Drawing loop.
        for row = 0 to (lines.Length-1) do
            for col = 0 to (lines.[row].Length-1) do
                if not (Char.IsWhiteSpace(lines.[row].[col])) then
                    img.SetPixel(col, row, Color.Black)

        // Save image.
        printf "Saving image data to %s.png\n" filename
        img.Save((filename+".png"), Imaging.ImageFormat.Png);
    0
