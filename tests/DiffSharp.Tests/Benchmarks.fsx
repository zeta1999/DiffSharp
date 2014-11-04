﻿
#r "../../src/DiffSharp/bin/Debug/DiffSharp.dll"

open DiffSharp.Util.LinearAlgebra

let duration f =
    let before = System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime.Ticks
    for i in 1..1000000 do // around 1000000 seems to work fine
        f() |> ignore
    let after = System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime.Ticks
    f(), (float (after - before)) / 1000000.


let x = 2.8
let xv = [|2.2; 3.5; 5.1|]
let v = [|1.2; 3.4; 5.2|]

//let res_fss, dur_fss = duration (fun () -> (fun x -> sin (sqrt (x + 2.) ** 4.)) x)
//let res_fvs, dur_fvs = duration (fun () -> (fun (x:float[]) -> sin (x.[0] * (sqrt (x.[1] + 2.) ** 4.) * log x.[2])) xv)
//let res_fvv, dur_fvv = duration (fun () -> (fun (x:float[]) -> [| sin x.[0]; sqrt (x.[1] + 2.) ** 4.; log x.[2]|]) xv)

let res_fss, dur_fss = duration (fun () -> (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_fvs, dur_fvs = duration (fun () -> (fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_fvv, dur_fvv = duration (fun () -> (fun (x:float[]) -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)


//
// *******************************************************************************************************************************************
// *******************************************************************************************************************************************
// *******************************************************************************************************************************************
// *******************************************************************************************************************************************





let res_diff_AD_Forward, dur_diff_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff_AD_Forward2, dur_diff_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff_AD_ForwardG, dur_diff_AD_ForwardG = duration (fun () -> DiffSharp.AD.ForwardG.ForwardGOps.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff_AD_ForwardGH, dur_diff_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff_AD_ForwardN, dur_diff_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff_AD_Reverse, dur_diff_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff_Numerical, dur_diff_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.diff (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
//let res_diff_Symbolic, dur_diff_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.diff <@ (fun x -> (sin (sqrt (x + 2.))) ** 3.) @> x)

let res_diff2_AD_Forward, dur_diff2_AD_Forward = 0., 0.
let res_diff2_AD_Forward2, dur_diff2_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.diff2 (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff2_AD_ForwardG, dur_diff2_AD_ForwardG = 0., 0.
let res_diff2_AD_ForwardGH, dur_diff2_AD_ForwardGH = 0., 0.
let res_diff2_AD_ForwardN, dur_diff2_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.diff2 (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff2_AD_Reverse, dur_diff2_AD_Reverse = 0., 0.
let res_diff2_Numerical, dur_diff2_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.diff2 (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
//let res_diff2_Symbolic, dur_diff2_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.diff2 <@ (fun x -> (sin (sqrt (x + 2.))) ** 3.) @> x)

let res_diffn_AD_Forward, dur_diffn_AD_Forward = 0., 0.
let res_diffn_AD_Forward2, dur_diffn_AD_Forward2 = 0., 0.
let res_diffn_AD_ForwardG, dur_diffn_AD_ForwardG = 0., 0.
let res_diffn_AD_ForwardGH, dur_diffn_AD_ForwardGH = 0., 0.
let res_diffn_AD_ForwardN, dur_diffn_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.diffn 2 (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diffn_AD_Reverse, dur_diffn_AD_Reverse = 0., 0.
let res_diffn_Numerical, dur_diffn_Numerical = 0., 0.
//let res_diffn_Symbolic, dur_diffn_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.diffn 2 <@ (fun x -> (sin (sqrt (x + 2.))) ** 3.) @> x)

let res_grad_AD_Forward, dur_grad_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.grad (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad_AD_Forward2, dur_grad_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.grad (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad_AD_ForwardG, dur_grad_AD_ForwardG = duration (fun () -> DiffSharp.AD.ForwardG.ForwardGOps.grad (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad_AD_ForwardGH, dur_grad_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.grad (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad_AD_ForwardN, dur_grad_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.grad (fun x ->(x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad_AD_Reverse, dur_grad_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.grad (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad_Numerical, dur_grad_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.grad (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_grad_Symbolic, dur_grad_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.grad <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_gradv_AD_Forward, dur_gradv_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.gradv (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
let res_gradv_AD_Forward2, dur_gradv_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.gradv (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
let res_gradv_AD_ForwardG, dur_gradv_AD_ForwardG = 0., 0.
let res_gradv_AD_ForwardGH, dur_gradv_AD_ForwardGH = 0., 0.
let res_gradv_AD_ForwardN, dur_gradv_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.gradv (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
let res_gradv_AD_Reverse, dur_gradv_AD_Reverse = 0., 0.
let res_gradv_Numerical, dur_gradv_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.gradv (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
//let res_gradv_Symbolic, dur_gradv_Symbolic = 0., 0.

let res_hessian_AD_Forward, dur_hessian_AD_Forward = 0., 0.
let res_hessian_AD_Forward2, dur_hessian_AD_Forward2 = 0., 0.
let res_hessian_AD_ForwardG, dur_hessian_AD_ForwardG = 0., 0.
let res_hessian_AD_ForwardGH, dur_hessian_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.hessian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_hessian_AD_ForwardN, dur_hessian_AD_ForwardN = 0., 0.
let res_hessian_AD_Reverse, dur_hessian_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.hessian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_hessian_Numerical, dur_hessian_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.hessian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_hessian_Symbolic, dur_hessian_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.hessian <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_gradhessian_AD_Forward, dur_gradhessian_AD_Forward = 0., 0.
let res_gradhessian_AD_Forward2, dur_gradhessian_AD_Forward2 = 0., 0.
let res_gradhessian_AD_ForwardG, dur_gradhessian_AD_ForwardG = 0., 0.
let res_gradhessian_AD_ForwardGH, dur_gradhessian_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.gradhessian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_gradhessian_AD_ForwardN, dur_gradhessian_AD_ForwardN = 0., 0.
let res_gradhessian_AD_Reverse, dur_gradhessian_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.gradhessian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_gradhessian_Numerical, dur_gradhessian_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.gradhessian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_gradhessian_Symbolic, dur_gradhessian_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.gradhessian <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_laplacian_AD_Forward, dur_laplacian_AD_Forward = 0., 0.
let res_laplacian_AD_Forward2, dur_laplacian_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.laplacian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian_AD_ForwardG, dur_laplacian_AD_ForwardG = 0., 0.
let res_laplacian_AD_ForwardGH, dur_laplacian_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.laplacian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian_AD_ForwardN, dur_laplacian_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.laplacian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian_AD_Reverse, dur_laplacian_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.laplacian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian_Numerical, dur_laplacian_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.laplacian (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_laplacian_Symbolic, dur_laplacian_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.laplacian <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_jacobian_AD_Forward, dur_jacobian_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian_AD_Forward2, dur_jacobian_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian_AD_ForwardG, dur_jacobian_AD_ForwardG = duration (fun () -> DiffSharp.AD.ForwardG.ForwardGOps.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian_AD_ForwardGH, dur_jacobian_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian_AD_ForwardN, dur_jacobian_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian_AD_Reverse, dur_jacobian_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian_Numerical, dur_jacobian_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.jacobian (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
//let res_jacobian_Symbolic, dur_jacobian_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.jacobian <@ fun (x:float[]) -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|] @> xv)

let res_jacobianv_AD_Forward, dur_jacobianv_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.jacobianv (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
let res_jacobianv_AD_Forward2, dur_jacobianv_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.jacobianv (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
let res_jacobianv_AD_ForwardG, dur_jacobianv_AD_ForwardG =  0., 0.
let res_jacobianv_AD_ForwardGH, dur_jacobianv_AD_ForwardGH =  0., 0.
let res_jacobianv_AD_ForwardN, dur_jacobianv_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.jacobianv (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
let res_jacobianv_AD_Reverse, dur_jacobianv_AD_Reverse =  0., 0.
let res_jacobianv_Numerical, dur_jacobianv_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.jacobianv (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
//let res_jacobianv_Symbolic, dur_jacobianv_Symbolic =  0., 0.

let row_originals = Vector.Create([| dur_fss; dur_fss; dur_fss; dur_fvs; dur_fvs; dur_fvs; dur_fvs; dur_fvs; dur_fvv; dur_fvv |])
let row_AD_Forward = Vector.Create([| dur_diff_AD_Forward; dur_diff2_AD_Forward; dur_diffn_AD_Forward; dur_grad_AD_Forward; dur_gradv_AD_Forward; dur_hessian_AD_Forward; dur_gradhessian_AD_Forward; dur_laplacian_AD_Forward; dur_jacobian_AD_Forward; dur_jacobianv_AD_Forward |]) / row_originals
let row_AD_Forward2 = Vector.Create([| dur_diff_AD_Forward2; dur_diff2_AD_Forward2; dur_diffn_AD_Forward2; dur_grad_AD_Forward2; dur_gradv_AD_Forward2; dur_hessian_AD_Forward2; dur_gradhessian_AD_Forward2; dur_laplacian_AD_Forward2; dur_jacobian_AD_Forward2; dur_jacobianv_AD_Forward2 |]) / row_originals
let row_AD_ForwardG = Vector.Create([| dur_diff_AD_ForwardG; dur_diff2_AD_ForwardG; dur_diffn_AD_ForwardG; dur_grad_AD_ForwardG; dur_gradv_AD_ForwardG; dur_hessian_AD_ForwardG; dur_gradhessian_AD_ForwardG; dur_laplacian_AD_ForwardG; dur_jacobian_AD_ForwardG; dur_jacobianv_AD_ForwardG |]) / row_originals
let row_AD_ForwardGH = Vector.Create([| dur_diff_AD_ForwardGH; dur_diff2_AD_ForwardGH; dur_diffn_AD_ForwardGH; dur_grad_AD_ForwardGH; dur_gradv_AD_ForwardGH; dur_hessian_AD_ForwardGH; dur_gradhessian_AD_ForwardGH; dur_laplacian_AD_ForwardGH; dur_jacobian_AD_ForwardGH; dur_jacobianv_AD_ForwardGH |]) / row_originals
let row_AD_ForwardN = Vector.Create([| dur_diff_AD_ForwardN; dur_diff2_AD_ForwardN; dur_diffn_AD_ForwardN; dur_grad_AD_ForwardN; dur_gradv_AD_ForwardN; dur_hessian_AD_ForwardN; dur_gradhessian_AD_ForwardN; dur_laplacian_AD_ForwardN; dur_jacobian_AD_ForwardN; dur_jacobianv_AD_ForwardN |]) / row_originals
let row_AD_Reverse = Vector.Create([| dur_diff_AD_Reverse; dur_diff2_AD_Reverse; dur_diffn_AD_Reverse; dur_grad_AD_Reverse; dur_gradv_AD_Reverse; dur_hessian_AD_Reverse; dur_gradhessian_AD_Reverse; dur_laplacian_AD_Reverse; dur_jacobian_AD_Reverse; dur_jacobianv_AD_Reverse |]) / row_originals
let row_Numerical = Vector.Create([| dur_diff_Numerical; dur_diff2_Numerical; dur_diffn_Numerical; dur_grad_Numerical; dur_gradv_Numerical; dur_hessian_Numerical; dur_gradhessian_Numerical; dur_laplacian_Numerical; dur_jacobian_Numerical; dur_jacobianv_Numerical |]) / row_originals
//let row_Symbolic = Vector.Create([| dur_diff_Symbolic; dur_diff2_Symbolic; dur_diffn_Symbolic; dur_grad_Symbolic; dur_gradv_Symbolic; dur_hessian_Symbolic; dur_gradhessian_Symbolic; dur_laplacian_Symbolic; dur_jacobian_Symbolic; dur_jacobianv_Symbolic |]) / row_originals

let benchmark = Matrix.Create([| row_AD_Forward; row_AD_Forward2; row_AD_ForwardG; row_AD_ForwardGH; row_AD_ForwardN; row_AD_Reverse; row_Numerical |])
//let benchmark = Matrix.Create([| row_AD_Forward; row_AD_Forward2; row_AD_ForwardG; row_AD_ForwardGH; row_AD_ForwardN; row_AD_Reverse; row_Numerical; row_Symbolic |])









//
// *******************************************************************************************************************************************
// *******************************************************************************************************************************************
// *******************************************************************************************************************************************
// *******************************************************************************************************************************************




let res_diff'_AD_Forward, dur_diff'_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff'_AD_Forward2, dur_diff'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff'_AD_ForwardG, dur_diff'_AD_ForwardG = duration (fun () -> DiffSharp.AD.ForwardG.ForwardGOps.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff'_AD_ForwardGH, dur_diff'_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff'_AD_ForwardN, dur_diff'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff'_AD_Reverse, dur_diff'_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff'_Numerical, dur_diff'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.diff' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
//let res_diff'_Symbolic, dur_diff'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.diff' <@ (fun x -> (sin (sqrt (x + 2.))) ** 3.) @> x)

let res_diff2'_AD_Forward, dur_diff2'_AD_Forward = 0., 0.
let res_diff2'_AD_Forward2, dur_diff2'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.diff2' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff2'_AD_ForwardG, dur_diff2'_AD_ForwardG = 0., 0.
let res_diff2'_AD_ForwardGH, dur_diff2'_AD_ForwardGH = 0., 0.
let res_diff2'_AD_ForwardN, dur_diff2'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.diff2' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diff2'_AD_Reverse, dur_diff2'_AD_Reverse = 0., 0.
let res_diff2'_Numerical, dur_diff2'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.diff2' (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
//let res_diff2'_Symbolic, dur_diff2'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.diff2' <@ (fun x -> (sin (sqrt (x + 2.))) ** 3.) @> x)

let res_diffn'_AD_Forward, dur_diffn'_AD_Forward = 0., 0.
let res_diffn'_AD_Forward2, dur_diffn'_AD_Forward2 = 0., 0.
let res_diffn'_AD_ForwardG, dur_diffn'_AD_ForwardG = 0., 0.
let res_diffn'_AD_ForwardGH, dur_diffn'_AD_ForwardGH = 0., 0.
let res_diffn'_AD_ForwardN, dur_diffn'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.diffn' 2 (fun x -> (sin (sqrt (x + 2.))) ** 3.) x)
let res_diffn'_AD_Reverse, dur_diffn'_AD_Reverse = 0., 0.
let res_diffn'_Numerical, dur_diffn'_Numerical = 0., 0.
//let res_diffn'_Symbolic, dur_diffn'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.diffn' 2 <@ (fun x -> (sin (sqrt (x + 2.))) ** 3.) @> x)

let res_grad'_AD_Forward, dur_grad'_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad'_AD_Forward2, dur_grad'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad'_AD_ForwardG, dur_grad'_AD_ForwardG = duration (fun () -> DiffSharp.AD.ForwardG.ForwardGOps.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad'_AD_ForwardGH, dur_grad'_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad'_AD_ForwardN, dur_grad'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad'_AD_Reverse, dur_grad'_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_grad'_Numerical, dur_grad'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.grad' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_grad'_Symbolic, dur_grad'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.grad' <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_gradv'_AD_Forward, dur_gradv'_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.gradv' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
let res_gradv'_AD_Forward2, dur_gradv'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.gradv' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
let res_gradv'_AD_ForwardG, dur_gradv'_AD_ForwardG = 0., 0.
let res_gradv'_AD_ForwardGH, dur_gradv'_AD_ForwardGH = 0., 0.
let res_gradv'_AD_ForwardN, dur_gradv'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.gradv' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
let res_gradv'_AD_Reverse, dur_gradv'_AD_Reverse = 0., 0.
let res_gradv'_Numerical, dur_gradv'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.gradv' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv v)
//let res_gradv'_Symbolic, dur_gradv'_Symbolic = 0., 0.

let res_hessian'_AD_Forward, dur_hessian'_AD_Forward = 0., 0.
let res_hessian'_AD_Forward2, dur_hessian'_AD_Forward2 = 0., 0.
let res_hessian'_AD_ForwardG, dur_hessian'_AD_ForwardG = 0., 0.
let res_hessian'_AD_ForwardGH, dur_hessian'_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.hessian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_hessian'_AD_ForwardN, dur_hessian'_AD_ForwardN = 0., 0.
let res_hessian'_AD_Reverse, dur_hessian'_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.hessian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_hessian'_Numerical, dur_hessian'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.hessian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_hessian'_Symbolic, dur_hessian'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.hessian' <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_gradhessian'_AD_Forward, dur_gradhessian'_AD_Forward = 0., 0.
let res_gradhessian'_AD_Forward2, dur_gradhessian'_AD_Forward2 = 0., 0.
let res_gradhessian'_AD_ForwardG, dur_gradhessian'_AD_ForwardG = 0., 0.
let res_gradhessian'_AD_ForwardGH, dur_gradhessian'_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.gradhessian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_gradhessian'_AD_ForwardN, dur_gradhessian'_AD_ForwardN = 0., 0.
let res_gradhessian'_AD_Reverse, dur_gradhessian'_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.gradhessian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_gradhessian'_Numerical, dur_gradhessian'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.gradhessian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_gradhessian'_Symbolic, dur_gradhessian'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.gradhessian' <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_laplacian'_AD_Forward, dur_laplacian'_AD_Forward = 0., 0.
let res_laplacian'_AD_Forward2, dur_laplacian'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.laplacian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian'_AD_ForwardG, dur_laplacian'_AD_ForwardG = 0., 0.
let res_laplacian'_AD_ForwardGH, dur_laplacian'_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.laplacian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian'_AD_ForwardN, dur_laplacian'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.laplacian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian'_AD_Reverse, dur_laplacian'_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.laplacian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
let res_laplacian'_Numerical, dur_laplacian'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.laplacian' (fun x -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1]) xv)
//let res_laplacian'_Symbolic, dur_laplacian'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.laplacian' <@ fun (x:float[]) -> (x.[0] * (sqrt (x.[1] + x.[2])) * (log x.[2])) ** x.[1] @> xv)

let res_jacobian'_AD_Forward, dur_jacobian'_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian'_AD_Forward2, dur_jacobian'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian'_AD_ForwardG, dur_jacobian'_AD_ForwardG = duration (fun () -> DiffSharp.AD.ForwardG.ForwardGOps.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian'_AD_ForwardGH, dur_jacobian'_AD_ForwardGH = duration (fun () -> DiffSharp.AD.ForwardGH.ForwardGHOps.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian'_AD_ForwardN, dur_jacobian'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian'_AD_Reverse, dur_jacobian'_AD_Reverse = duration (fun () -> DiffSharp.AD.Reverse.ReverseOps.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
let res_jacobian'_Numerical, dur_jacobian'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.jacobian' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv)
//let res_jacobian'_Symbolic, dur_jacobian'_Symbolic = duration (fun () -> DiffSharp.Symbolic.SymbolicOps.jacobian' <@ fun (x:float[]) -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|] @> xv)

let res_jacobianv'_AD_Forward, dur_jacobianv'_AD_Forward = duration (fun () -> DiffSharp.AD.Forward.ForwardOps.jacobianv' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
let res_jacobianv'_AD_Forward2, dur_jacobianv'_AD_Forward2 = duration (fun () -> DiffSharp.AD.Forward2.Forward2Ops.jacobianv' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
let res_jacobianv'_AD_ForwardG, dur_jacobianv'_AD_ForwardG = 0., 0.
let res_jacobianv'_AD_ForwardGH, dur_jacobianv'_AD_ForwardGH = 0., 0.
let res_jacobianv'_AD_ForwardN, dur_jacobianv'_AD_ForwardN = duration (fun () -> DiffSharp.AD.ForwardN.ForwardNOps.jacobianv' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
let res_jacobianv'_AD_Reverse, dur_jacobianv'_AD_Reverse = 0., 0.
let res_jacobianv'_Numerical, dur_jacobianv'_Numerical = duration (fun () -> DiffSharp.Numerical.NumericalOps.jacobianv' (fun x -> [|(sin x.[0]) ** x.[1]; sqrt (x.[1] + x.[2]); log (x.[0] * x.[2])|]) xv v)
//let res_jacobianv'_Symbolic, dur_jacobianv'_Symbolic = 0., 0.

let row_originals' = Vector.Create([| dur_fss; dur_fss; dur_fss; dur_fvs; dur_fvs; dur_fvs; dur_fvs; dur_fvs; dur_fvv; dur_fvv |])
let row_AD_Forward' = Vector.Create([| dur_diff'_AD_Forward; dur_diff2'_AD_Forward; dur_diffn'_AD_Forward; dur_grad'_AD_Forward; dur_gradv'_AD_Forward; dur_hessian'_AD_Forward; dur_gradhessian'_AD_Forward; dur_laplacian'_AD_Forward; dur_jacobian'_AD_Forward; dur_jacobianv'_AD_Forward |]) / row_originals'
let row_AD_Forward2' = Vector.Create([| dur_diff'_AD_Forward2; dur_diff2'_AD_Forward2; dur_diffn'_AD_Forward2; dur_grad'_AD_Forward2; dur_gradv'_AD_Forward2; dur_hessian'_AD_Forward2; dur_gradhessian'_AD_Forward2; dur_laplacian'_AD_Forward2; dur_jacobian'_AD_Forward2; dur_jacobianv'_AD_Forward2 |]) / row_originals'
let row_AD_ForwardG' = Vector.Create([| dur_diff'_AD_ForwardG; dur_diff2'_AD_ForwardG; dur_diffn'_AD_ForwardG; dur_grad'_AD_ForwardG; dur_gradv'_AD_ForwardG; dur_hessian'_AD_ForwardG; dur_gradhessian'_AD_ForwardG; dur_laplacian'_AD_ForwardG; dur_jacobian'_AD_ForwardG; dur_jacobianv'_AD_ForwardG |]) / row_originals'
let row_AD_ForwardGH' = Vector.Create([| dur_diff'_AD_ForwardGH; dur_diff2'_AD_ForwardGH; dur_diffn'_AD_ForwardGH; dur_grad'_AD_ForwardGH; dur_gradv'_AD_ForwardGH; dur_hessian'_AD_ForwardGH; dur_gradhessian'_AD_ForwardGH; dur_laplacian'_AD_ForwardGH; dur_jacobian'_AD_ForwardGH; dur_jacobianv'_AD_ForwardGH |]) / row_originals'
let row_AD_ForwardN' = Vector.Create([| dur_diff'_AD_ForwardN; dur_diff2'_AD_ForwardN; dur_diffn'_AD_ForwardN; dur_grad'_AD_ForwardN; dur_gradv'_AD_ForwardN; dur_hessian'_AD_ForwardN; dur_gradhessian'_AD_ForwardN; dur_laplacian'_AD_ForwardN; dur_jacobian'_AD_ForwardN; dur_jacobianv'_AD_ForwardN |]) / row_originals'
let row_AD_Reverse' = Vector.Create([| dur_diff'_AD_Reverse; dur_diff2'_AD_Reverse; dur_diffn'_AD_Reverse; dur_grad'_AD_Reverse; dur_gradv'_AD_Reverse; dur_hessian'_AD_Reverse; dur_gradhessian'_AD_Reverse; dur_laplacian'_AD_Reverse; dur_jacobian'_AD_Reverse; dur_jacobianv'_AD_Reverse |]) / row_originals'
let row_Numerical' = Vector.Create([| dur_diff'_Numerical; dur_diff2'_Numerical; dur_diffn'_Numerical; dur_grad'_Numerical; dur_gradv'_Numerical; dur_hessian'_Numerical; dur_gradhessian'_Numerical; dur_laplacian'_Numerical; dur_jacobian'_Numerical; dur_jacobianv'_Numerical |]) / row_originals'
//let row_Symbolic = Vector.Create([| dur_diff'_Symbolic; dur_diff2'_Symbolic; dur_diffn'_Symbolic; dur_grad'_Symbolic; dur_gradv'_Symbolic; dur_hessian'_Symbolic; dur_gradhessian'_Symbolic; dur_laplacian'_Symbolic; dur_jacobian'_Symbolic; dur_jacobianv'_Symbolic |]) / row_originals'

let benchmark' = Matrix.Create([| row_AD_Forward'; row_AD_Forward2'; row_AD_ForwardG'; row_AD_ForwardGH'; row_AD_ForwardN'; row_AD_Reverse'; row_Numerical' |])
//let benchmark' = Matrix.Create([| row_AD_Forward'; row_AD_Forward2'; row_AD_ForwardG'; row_AD_ForwardGH'; row_AD_ForwardN'; row_AD_Reverse'; row_Numerical'; row_Symbolic' |])






System.Windows.Forms.Clipboard.SetText(benchmark.ToMathematicaString())