import { useEffect, useMemo, useState } from "react";
import PropertyCard from "../components/Property";
import AddProperties from "./AddProperties";
import { getProperties } from "../services/property/PropertyServices";
import { PropertyTypes } from "../interfaces/IPropertyTypes";
import debounce from "lodash.debounce";

const Home = () => {
    const [showAddModal, setShowAddModal] = useState<boolean>(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [filter, setFilter] = useState<any>({});
    const [properties, setProperties] = useState<any[]>([]);
    const [totalPages, setTotalPages] = useState(0);
    const [loading, setLoading] = useState(false);

    const debouncedFetch = useMemo(
        () =>
            debounce(async (page: number, filterData: any) => {
                try {
                    setLoading(true);
                    const response = await getProperties({
                        page,
                        ...filterData,
                    });
                    setProperties(response.data.properties || []);
                    setTotalPages(response.data.pageSize || 0);
                } catch (error) {
                    console.log("Error fetching properties:", error);
                } finally {
                    setLoading(false);
                }
            }, 500),
        []
    );

    useEffect(() => {
        debouncedFetch(currentPage, filter);
        return () => {
            debouncedFetch.cancel();
        };
    }, [currentPage, filter, debouncedFetch]);

    const handleFilterChange = (newFilter: any) => {
        setFilter((prev: any) => ({ ...prev, ...newFilter }));
        setCurrentPage(1);
    };

    return (
        <div
            className="container-fluid"
            style={{
                display: "flex",
                flexDirection: "column",
                height: "100vh",
                paddingTop: "70px"
            }}
        >
            <div
                className="bg-white shadow-sm p-3"
                style={{
                    position: "sticky",
                    top: 0,
                    zIndex: 10
                }}
            >
                <div className="d-flex flex-column flex-md-row align-items-start align-items-md-center justify-content-between">
                    <h2
                        className="mb-3 mb-md-0"
                        style={{
                            fontWeight: "bold",
                            letterSpacing: "1px",
                            textTransform: "uppercase",
                        }}
                    >
                        Properties
                    </h2>

                    <div className="d-flex flex-column flex-md-row align-items-start align-items-md-center">
                        {/* Add Property */}
                        <button
                            className="btn me-2 btn-sm"
                            style={{
                                borderRadius: 8,
                                color: "white",
                                backgroundColor: "#5a809b",
                            }}
                            onClick={() => setShowAddModal(true)}
                        >
                            Add Property
                        </button>

                        <AddProperties
                            show={showAddModal}
                            onClose={() => setShowAddModal(false)}
                            onAdd={(newProperty) => {
                                setProperties([ ...properties]);
                                setShowAddModal(false);
                            }}
                        />

                        <div className="d-flex flex-wrap align-items-center gap-2">
                            <select
                                className="form-select form-select-sm"
                                style={{ width: "160px" }}
                                value={filter.type || ""}
                                onChange={(e) =>
                                    handleFilterChange({
                                        type: e.target.value || undefined,
                                    })
                                }
                            >
                                <option value="">All Types</option>
                                {Object.values(PropertyTypes).map((type) => (
                                    <option key={type} value={type}>
                                        {type}
                                    </option>
                                ))}
                            </select>

                            <input
                                type="number"
                                className="form-control form-control-sm"
                                placeholder="Min Price"
                                style={{ width: "120px" }}
                                value={filter.minPrice || ""}
                                onChange={(e) => {
                                    const val = Number(e.target.value);
                                    handleFilterChange({
                                        minPrice: e.target.value !== "" ? val : undefined,
                                    });
                                }}
                            />

                            <input
                                type="number"
                                className="form-control form-control-sm"
                                placeholder="Max Price"
                                style={{ width: "120px" }}
                                value={filter.maxPrice || ""}
                                onChange={(e) => {
                                    const val = Number(e.target.value);
                                    handleFilterChange({
                                        maxPrice: e.target.value !== "" ? val : undefined,
                                    });
                                }}
                            />

                            <select
                                className="form-select form-select-sm"
                                style={{ width: "140px" }}
                                value={filter.sortBy || ""}
                                onChange={(e) =>
                                    handleFilterChange({
                                        sortBy: e.target.value,
                                    })
                                }
                            >
                                <option disabled value="">
                                    Sort by Price
                                </option>
                                <option value="Asce">Price: Low to High</option>
                                <option value="Desc">Price: High to Low</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>

            <div
                style={{
                    flex: 1,
                    overflowY: "auto",
                    padding: "1rem"
                }}
            >
                {loading ? (
                    <p>Loading properties...</p>
                ) : properties.length === 0 ? (
                    <p className="text-center text-muted fw-semibold">
                        No properties found.
                    </p>
                ) : (
                    <div className="row g-1" style={{margin: "0% 11%"}}>
                        {properties.map((property) => (
                            <div key={property.id} className="col-md-3 mb-2">
                                <PropertyCard property={property} />
                            </div>
                        ))}
                    </div>
                )}

                <nav aria-label="Properties pagination">
                    <ul className="pagination justify-content-center">
                        <li className={`page-item${currentPage === 1 ? " disabled" : ""}`}>
                            <button
                                className="page-link"
                                onClick={() => setCurrentPage(currentPage - 1)}
                                disabled={currentPage === 1}
                            >
                                Previous
                            </button>
                        </li>
                        {[...Array(totalPages)].map((_, idx) => (
                            <li
                                key={idx}
                                className={`page-item${currentPage === idx + 1 ? " active" : ""}`}
                            >
                                <button
                                    className="page-link"
                                    onClick={() => setCurrentPage(idx + 1)}
                                >
                                    {idx + 1}
                                </button>
                            </li>
                        ))}
                        <li
                            className={`page-item${currentPage === totalPages ? " disabled" : ""}`}
                        >
                            <button
                                className="page-link"
                                onClick={() => setCurrentPage(currentPage + 1)}
                                disabled={currentPage === totalPages}
                            >
                                Next
                            </button>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
    );
};

export default Home;
