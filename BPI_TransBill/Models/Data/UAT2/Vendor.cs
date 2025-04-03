using System;
using System.Collections.Generic;

namespace BPI_TransBill.Models.Data.UAT2;

public partial class Vendor
{
    public string Company { get; set; } = null!;

    public byte[] SysRevId { get; set; } = null!;

    public Guid SysRowId { get; set; }

    public int VendorNum { get; set; }

    public string OrgType { get; set; } = null!;

    public virtual Vendor2 Vendor2 { get; set; } = null!;
}
