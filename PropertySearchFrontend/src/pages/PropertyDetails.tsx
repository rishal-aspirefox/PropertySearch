import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import type { Property } from "../interfaces/IProperty";
import {
  fetchAverageSpaceSize,
  getPropertyById,
} from "../services/property/PropertyServices";
import { toast } from "react-toastify";

const PropertyDetails = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [property, setProperty] = useState<Property | null>(null);
  const [loading, setLoading] = useState(true);
  const [averageSpaceSize, setAverageSpaceSize] = useState<any>(null);

  useEffect(() => {
    if (id) {
      setLoading(true);
      async function getProperty() {
        try {
          const response = await getPropertyById(id);
          const avgSpace = await fetchAverageSpaceSize(id);

          if (!response.data) {
            toast.error("Property not found");
          }

          setProperty(response.data);
          setAverageSpaceSize(avgSpace.data);
        } catch (error) {
          console.error("Error fetching property:", error);
          setProperty(null);
        } finally {
          setLoading(false);
        }
      }
      getProperty();
    }
  }, [id]);

  if (loading) {
    return (
      <div className="text-center my-5" role="status" aria-live="polite">
        <div className="spinner-border text-primary" role="status" aria-label="Loading property details" />
        <div>Loading property details...</div>
      </div>
    );
  }

  if (!property) {
    return (
      <div
        className="alert alert-danger mt-5"
        role="alert"
        aria-label="Property not found"
      >
        Property not found.
      </div>
    );
  }

  return (
    <div aria-labelledby="property-details-heading" style={{ marginTop: "60px" }}>
      <div className="w-100 position-relative">
        <button
          className="btn btn-secondary px-4 position-absolute"
          style={{
            top: "20px",
            left: "20px",
            borderRadius: "8px",
            zIndex: 2,
          }}
          onClick={() => navigate(-1)}
          aria-label="Go back to previous page"
        >
          ← Back
        </button>

        {/* Image */}
        <img
          src="https://img.freepik.com/free-photo/house-isolated-field_1303-23773.jpg?t=st=1755848409~exp=1755852009~hmac=ab42b26eb0b557f3a3a7844467628a0a55e400a372cbaf557cfdb98c171af0b6&w=1480"
          alt="Property Banner"
          className="img-fluid w-100"
          style={{
            height: "400px",
            objectFit: "cover",
            borderRadius: "0px",
          }}
        />
      </div>

      {/* Property Info */}
      <div className="container py-4">
        <h2
          id="property-details-heading"
          className="fw-bold text-dark mb-2"
          aria-label={`Property address: ${property.address}`}
        >
          {property.address}
        </h2>
        <span
          className="badge mb-2"
          style={{
            fontSize: "1em",
            background: "linear-gradient(45deg, #1976d2, #42a5f5)",
            padding: "0.6em 1em",
            borderRadius: "8px",
          }}
          aria-label={`Property type: ${property.type}`}
        >
          {property.type}
        </span>
        <p className="mb-2 mt-2" aria-label={`Price: ${property.price.toLocaleString()}`}>
          <strong className="me-2">Price:</strong>
          <span
            style={{
              color: "#2e7d32",
              fontWeight: 700,
              fontSize: "1.25em",
            }}
          >
            ${property.price.toLocaleString()}
          </span>
        </p>
        {property.description && (
          <p
            className="text-muted"
            style={{ maxWidth: "900px" }}
            aria-label="Property description"
          >
            {property.description}
          </p>
        )}
      </div>

      {/* Average Space Stats */}
      {averageSpaceSize && (
        <div className="container py-4" aria-label="Property space statistics">
          <h5 className="fw-bold mb-3">Space Statistics</h5>
          <div className="row text-center">
            <div className="col-6 col-md-3 mb-3">
              <div className="p-3 shadow-sm rounded bg-white border">
                <h6 className="fw-bold text-primary mb-1" aria-label={`Total spaces: ${averageSpaceSize.totalSpaces}`}>
                  {averageSpaceSize.totalSpaces}
                </h6>
                <p className="text-muted mb-0">Total Spaces</p>
              </div>
            </div>
            <div className="col-6 col-md-3 mb-3">
              <div className="p-3 shadow-sm rounded bg-white border">
                <h6 className="fw-bold text-success mb-1" aria-label={`Average size: ${averageSpaceSize.averageSize} sqft`}>
                  {averageSpaceSize.averageSize} sqft
                </h6>
                <p className="text-muted mb-0">Average Size</p>
              </div>
            </div>
            <div className="col-6 col-md-3 mb-3">
              <div className="p-3 shadow-sm rounded bg-white border">
                <h6 className="fw-bold text-warning mb-1" aria-label={`Max size: ${averageSpaceSize.maxSize} sqft`}>
                  {averageSpaceSize.maxSize} sqft
                </h6>
                <p className="text-muted mb-0">Max Size</p>
              </div>
            </div>
            <div className="col-6 col-md-3 mb-3">
              <div className="p-3 shadow-sm rounded bg-white border">
                <h6 className="fw-bold text-danger mb-1" aria-label={`Min size: ${averageSpaceSize.minSize} sqft`}>
                  {averageSpaceSize.minSize} sqft
                </h6>
                <p className="text-muted mb-0">Min Size</p>
              </div>
            </div>
          </div>
        </div>
      )}

      {/* Spaces */}
      {property.spaces.length > 0 && (
        <div className="container py-4" aria-label="List of spaces">
          <h5 className="fw-bold mb-3">Spaces</h5>
          <div className="row">
            {property.spaces.map((space) => (
              <div key={space.id} className="col-12 col-md-6 mb-3">
                <div
                  className="p-3 h-100 shadow-sm border"
                  style={{
                    borderRadius: "12px",
                    background: "#fff",
                  }}
                  aria-label={`Space type: ${space.type}, size: ${space.size} sqft`}
                >
                  <h6 className="fw-bold text-primary mb-2">{space.type}</h6>
                  <p className="mb-1">
                    <strong>Size:</strong> {space.size} sqft
                  </p>
                  {space.description && (
                    <p className="text-muted" aria-label="Space description">{space.description}</p>
                  )}
                </div>
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default PropertyDetails;
